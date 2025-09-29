using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionProjectSystem.Domain.Entities;

namespace OnionProjectSystem.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category1 = new()
            {
                Id = 1,
                Name = "Electronics",
                Priorty = 1,
                ParentId = 0,
                CreatedBy = "System", 
            };
            Category category2 = new()
            {
                Id = 2,
                Name = "Fashion",
                Priorty = 2,
                ParentId = 0,
                CreatedBy = "System",
            };
            Category parent1 = new()
            {
                Id = 3,
                Name = "Computer",
                Priorty = 1,
                ParentId = 1,
                CreatedBy = "System",
            };
            Category parent2 = new()
            {
                Id = 4,
                Name = "Woman",
                Priorty = 1,
                ParentId = 2,
                CreatedBy = "System",
            };
            builder.HasData(category1, category2, parent1, parent2);
        }
    }
}
