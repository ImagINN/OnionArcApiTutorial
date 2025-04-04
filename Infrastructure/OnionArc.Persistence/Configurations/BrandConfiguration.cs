using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(b => b.Name).HasMaxLength(256);

        Brand brand1 = new()
        {
            Id = 1,
            Name = "Elektronik", // Sabit değer
            Logo = "https://picsum.photos/id/1011/200/300", // Sabit URL
            CreatedDate = new DateTime(2024, 1, 1),
            UpdatedDate = new DateTime(2024, 1, 1),
            IsDeleted = false
        };

        Brand brand2 = new()
        {
            Id = 2,
            Name = "Mobilya",
            Logo = "https://picsum.photos/id/1012/200/300",
            CreatedDate = new DateTime(2024, 1, 2),
            UpdatedDate = new DateTime(2024, 1, 2),
            IsDeleted = true
        };

        Brand brand3 = new()
        {
            Id = 3,
            Name = "Giyim",
            Logo = "https://picsum.photos/id/1013/200/300",
            CreatedDate = new DateTime(2024, 1, 3),
            UpdatedDate = new DateTime(2024, 1, 3),
            IsDeleted = false
        };

        builder.HasData(brand1, brand2, brand3);
    }

}
