using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArc.Domain.Entities;
using System;

namespace OnionArc.Persistence.Configurations;

public class DetailConfiguration : IEntityTypeConfiguration<Detail>
{
    public void Configure(EntityTypeBuilder<Detail> builder)
    {
        Detail detail1 = new()
        {
            Id = 1,
            Title = "Samsung Galaxy A52",
            Description = "Orta segment akıllı telefon. Uygun fiyatlı ve kaliteli.",
            CategoryId = 1,
            CreatedDate = new DateTime(2024, 1, 1),
            UpdatedDate = new DateTime(2024, 1, 1),
            IsDeleted = false
        };

        Detail detail2 = new()
        {
            Id = 2,
            Title = "Erkek Mont",
            Description = "Kış ayları için kalın, su geçirmez mont.",
            CategoryId = 2,
            CreatedDate = new DateTime(2024, 1, 2),
            UpdatedDate = new DateTime(2024, 1, 2),
            IsDeleted = false
        };

        Detail detail3 = new()
        {
            Id = 3,
            Title = "Gaming Laptop",
            Description = "Yüksek performanslı, oyun odaklı dizüstü bilgisayar.",
            CategoryId = 3,
            CreatedDate = new DateTime(2024, 1, 3),
            UpdatedDate = new DateTime(2024, 1, 3),
            IsDeleted = true
        };

        Detail detail4 = new()
        {
            Id = 4,
            Title = "Kadın Elbise",
            Description = "Günlük kullanım için şık ve rahat elbise.",
            CategoryId = 4,
            CreatedDate = new DateTime(2024, 1, 4),
            UpdatedDate = new DateTime(2024, 1, 4),
            IsDeleted = false
        };

        builder.HasData(detail1, detail2, detail3, detail4);
    }
}
