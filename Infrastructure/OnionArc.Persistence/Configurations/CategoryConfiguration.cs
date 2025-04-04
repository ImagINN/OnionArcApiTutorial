using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArc.Domain.Entities;
using System;

namespace OnionArc.Persistence.Configurations;

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
            CreatedDate = new DateTime(2024, 1, 1),
            UpdatedDate = new DateTime(2024, 1, 1),
            IsDeleted = false
        };

        Category category2 = new()
        {
            Id = 2,
            Name = "Moda",
            Priorty = 2,
            ParentId = 0,
            CreatedDate = new DateTime(2024, 1, 2),
            UpdatedDate = new DateTime(2024, 1, 2),
            IsDeleted = false
        };

        Category parent1 = new()
        {
            Id = 3,
            Name = "Computer",
            Priorty = 1,
            ParentId = 1,
            CreatedDate = new DateTime(2024, 1, 3),
            UpdatedDate = new DateTime(2024, 1, 3),
            IsDeleted = false
        };

        Category parent2 = new()
        {
            Id = 4,
            Name = "Woman",
            Priorty = 1,
            ParentId = 2,
            CreatedDate = new DateTime(2024, 1, 4),
            UpdatedDate = new DateTime(2024, 1, 4),
            IsDeleted = false
        };

        builder.HasData(category1, category2, parent1, parent2);
    }
}
