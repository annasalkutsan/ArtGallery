using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        // Определение первичного ключа
        builder.HasKey(x => x.Id);

        // Настройка обязательности свойств
        builder.Property(x => x.Path).IsRequired();
        
    }
}