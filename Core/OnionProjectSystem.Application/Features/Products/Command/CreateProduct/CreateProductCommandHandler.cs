using MediatR;
using Microsoft.AspNetCore.Http;
using OnionProjectSystem.Application.Bases;
using OnionProjectSystem.Application.Features.Products.Rules;
using OnionProjectSystem.Application.Interfaces.AutoMapper;
using OnionProjectSystem.Application.Interfaces.UnitOfWorks;
using OnionProjectSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest,Unit>
    {
        private readonly ProductRules _productRules;
        public CreateProductCommandHandler(ProductRules productRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor):base(mapper, unitOfWork, httpContextAccessor)
        {
            _productRules = productRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

            await _productRules.ProductTitleMustNotBeSame(products, request.Title);

            Product product = new Product(request.Title, request.Description, request.BrandId, request.Price, request.Discount, request.Stock);

            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);

            if (await _unitOfWork.SaveAsync()>0)
            {
                foreach (var categoryId in request.CategoryIds)
                {                
                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new ProductCategory
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });
                }
                await _unitOfWork.SaveAsync();
            }

            return Unit.Value;
        }
    }
}
