using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Определение первичного ключа
        builder.HasKey(x => x.Id);

        // Настройка обязательности свойств
        builder.Property(x => x.OrderDate).IsRequired();
        builder.Property(x => x.Status).IsRequired();

        // Определение связи "один ко многим" с сущностью User
        builder.HasOne(x => x.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(x => x.UserId);
    }
}