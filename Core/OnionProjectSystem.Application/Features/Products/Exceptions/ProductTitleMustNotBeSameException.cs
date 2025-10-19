using OnionProjectSystem.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException:BaseException
    {
        public ProductTitleMustNotBeSameException():base("Product title must not be same with another product title.")
        {
        }
    }
}
