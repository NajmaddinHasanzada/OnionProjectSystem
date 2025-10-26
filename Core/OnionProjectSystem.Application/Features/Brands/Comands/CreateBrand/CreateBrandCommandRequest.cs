using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Application.Features.Brands.Comands.CreateBrand
{
    public class CreateBrandCommandRequest:IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
