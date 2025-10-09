using MediatR;
using OnionProjectSystem.Application.Interfaces.AutoMapper;
using OnionProjectSystem.Application.Interfaces.UnitOfWorks;
using OnionProjectSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {    
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products =await _unitOfWork.GetReadRepository<Product>().GetAllAsync();
            //foreach (var product in products)
            //{
            //    response.Add(new GetAllProductsQueryResponse
            //    {
            //        Title = product.Title,
            //        Description = product.Description,
            //        Price = product.Price - (product.Price*product.Discount/100),
            //        Discount = product.Discount,
            //        Stock = product.Stock
            //    });
            //}
            var map = _mapper.Map<GetAllProductsQueryResponse, Product>(products);
            foreach (var item in map)
            {
                item.Price = item.Price - (item.Price * item.Discount / 100);
            }
            return map;
        }
    }
}
