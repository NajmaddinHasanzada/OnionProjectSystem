using Bogus;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnionProjectSystem.Application.Bases;
using OnionProjectSystem.Application.Interfaces.AutoMapper;
using OnionProjectSystem.Application.Interfaces.UnitOfWorks;
using OnionProjectSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Application.Features.Brands.Comands.CreateBrand
{
    public class CreateBrandCommandHandler:BaseHandler,IRequestHandler<CreateBrandCommandRequest,Unit>
    {
        public CreateBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Faker faker = new Faker();
            List<Brand> brands = new List<Brand>();

            for (int i = 0; i < 100000; i++)
            {
                brands.Add(new Brand
                {
                    Name = faker.Commerce.Department(1)
                });
            }
            await _unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brands);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
