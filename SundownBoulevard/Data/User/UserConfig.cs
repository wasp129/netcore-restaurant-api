using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SundownBoulevard.Models.User;

namespace SundownBoulevard.Data
{
    public class UserConfig : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder
                .Property(p => p.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.HasMany(r => r.Reservations);
        }
    }
}