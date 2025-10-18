using OnionProjectSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Domain.Entities
{
    public class Product:EntityBase
    {
        public Product() { }
        public Product(string title, string description, int brandId, decimal price, decimal discount, int stock)
        {
            Title = title;
            BrandId = brandId;
            Price = price;
            Discount = discount;
            Stock = stock;
            Description = description;
        }
        public string Title { get; set; }
        //public required string ImagePath { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Stock { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
