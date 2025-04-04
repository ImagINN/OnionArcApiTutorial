using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArc.Domain.Entities;
using System;

namespace OnionArc.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        Product product1 = new()
        {
            Id = 1,
            Title = "Bluetooth Kulaklık",
            Description = "Yüksek ses kalitesi, uzun pil ömrü ile kablosuz kulaklık.",
            Price = 349.99m,
            Discount = 15.0m,
            BrandId = 1,
            CreatedDate = new DateTime(2024, 1, 1),
            UpdatedDate = new DateTime(2024, 1, 1),
            IsDeleted = false
        };

        Product product2 = new()
        {
            Id = 2,
            Title = "Deri Cüzdan",
            Description = "Hakiki deriden üretilmiş, çok bölmeli erkek cüzdanı.",
            Price = 199.90m,
            Discount = 10.0m,
            BrandId = 2,
            CreatedDate = new DateTime(2024, 1, 2),
            UpdatedDate = new DateTime(2024, 1, 2),
            IsDeleted = false
        };

        Product product3 = new()
        {
            Id = 3,
            Title = "Oyuncu Mouse",
            Description = "RGB ışıklı, yüksek hassasiyetli gaming mouse.",
            Price = 499.00m,
            Discount = 20.0m,
            BrandId = 3,
            CreatedDate = new DateTime(2024, 1, 3),
            UpdatedDate = new DateTime(2024, 1, 3),
            IsDeleted = false
        };

        builder.HasData(product1, product2, product3);
    }
}
