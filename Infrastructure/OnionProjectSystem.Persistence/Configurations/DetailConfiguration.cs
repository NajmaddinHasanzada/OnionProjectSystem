using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionProjectSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Persistence.Configurations
{
    public class DetailConfiguration:IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.HasData(
    new Detail
    {
        Id = 1,
        Title = "Basic Electronics",
        Description = "Standard electronic components.",
        CategoryId = 1,
        CreatedBy = "System",
        CreatedDate = new DateTime(2025, 1, 1)
    },
    new Detail
    {
        Id = 2,
        Title = "Home Appliances",
        Description = "Household and kitchen appliances.",
        CategoryId = 3,
        CreatedBy = "System",
        CreatedDate = new DateTime(2025, 1, 1),
        IsDeleted = true
    },
    new Detail
    {
        Id = 3,
        Title = "Outdoor Equipment",
        Description = "Tools for outdoor activities.",
        CategoryId = 4,
        CreatedBy = "System",
        CreatedDate = new DateTime(2025, 1, 1)
    }
);

        }
    }
}
