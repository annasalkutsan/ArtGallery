using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class PaintingConfiguration : IEntityTypeConfiguration<Painting>
{
    public void Configure(EntityTypeBuilder<Painting> builder)
    {
        // Определение первичного ключа
        builder.HasKey(x => x.Id);

        // Настройка обязательности свойств
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.Price).IsRequired();

        
        // Определение связи "один к одному" с сущностью Author
        builder.HasOne(x => x.Author)
            .WithMany(a => a.Paintings)
            .HasForeignKey(x => x.AuthorId);

        // Определение связи "один к одному" с сущностью Order
        builder.HasOne(x => x.Order)
            .WithOne(o => o.Painting) // Указание навигационного свойства у сущности Order
            .HasForeignKey<Order>(o => o.PaintingId); // Внешний ключ, указывающий на Painting
    }
}