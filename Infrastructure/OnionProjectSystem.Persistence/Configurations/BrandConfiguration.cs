using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionProjectSystem.Domain.Entities;

namespace OnionProjectSystem.Persistence.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.HasData(
     new Brand
     {
         Id = 1,
         Name = "Electronics",
         CreatedBy = "System",
         CreatedDate = new DateTime(2025, 1, 1)
     },
     new Brand
     {
         Id = 2,
         Name = "Clothing",
         CreatedBy = "System",
         CreatedDate = new DateTime(2025, 1, 1)
     },
     new Brand
     {
         Id = 3,
         Name = "Books",
         CreatedBy = "System",
         CreatedDate = new DateTime(2025, 1, 1),
         IsDeleted = true
     }
 );

        }
    }
}
