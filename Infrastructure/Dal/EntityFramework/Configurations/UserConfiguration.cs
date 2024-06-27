using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Определение первичного ключа
        builder.HasKey(x => x.Id);

        // Настройка обязательности свойств
        builder.Property(x => x.NickName).IsRequired();
        builder.Property(x => x.PasswordHash);
        builder.Property(x => x.PasswordSalt);
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Role).IsRequired();

        // Определение владеемой сущности
        builder.OwnsOne(x => x.PaymentDetails, paymentDetails =>
        {
            paymentDetails.Property(x => x.FirstName);
            paymentDetails.Property(x => x.LastName);
            paymentDetails.Property(x => x.CardNumber);
            paymentDetails.Property(x => x.CheckingAccount).IsRequired();
        });

        // Определение связи "один ко многим" с сущностью Order
        builder.HasMany(x => x.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId);
    }
}