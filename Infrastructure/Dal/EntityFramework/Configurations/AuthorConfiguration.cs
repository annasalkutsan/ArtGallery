using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        // Определение первичного ключа
        builder.HasKey(x => x.Id);

        // Настройка обязательности свойств
        builder.Property(x => x.NumberOfWorks).IsRequired();
        builder.Property(x => x.Description);
   

        builder.OwnsOne(x => x.FullName, fullName =>
        {
            fullName.Property(x => x.FirstName).IsRequired();
            fullName.Property(x => x.LastName);
            fullName.Property(x => x.MiddleName);
        });
            
        // Определение связи "один ко многим" с сущностью Painting
        builder.HasMany(x => x.Paintings)
            .WithOne(p => p.Author)
            .HasForeignKey(p => p.AuthorId);
    }
}