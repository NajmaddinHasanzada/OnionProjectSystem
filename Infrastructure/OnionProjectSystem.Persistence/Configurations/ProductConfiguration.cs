using Bogus;
using Microsoft.EntityFrameworkCore;
using OnionProjectSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Persistence.Configurations
{
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
    new Product
    {
        Id = 1,
        Title = "Laptop Pro 15",
        Price = 1499.99m,
        Stock = 50,
        Discount = 5.0m,
        BrandId = 1,
        Description = "High performance laptop for professionals.",
        CreatedBy = "System",
        CreatedDate = new DateTime(2025, 1, 1)
    },
    new Product
    {
        Id = 2,
        Title = "Smartphone X",
        Price = 999.00m,
        Stock = 30,
        Discount = 3.0m,
        BrandId = 3,
        Description = "Latest generation smartphone.",
        CreatedBy = "System",
        CreatedDate = new DateTime(2025, 1, 1),
        IsDeleted = true
    }
);

        }
    }
}
