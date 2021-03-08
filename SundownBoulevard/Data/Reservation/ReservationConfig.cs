using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SundownBoulevard.Models.Reservation;

namespace SundownBoulevard.Data.Reservation
{
    public class ReservationConfig : IEntityTypeConfiguration<ReservationModel>
    {
        public void Configure(EntityTypeBuilder<ReservationModel> builder)
        {
            builder
                .Property(p => p.Id)
                .HasDefaultValueSql("uuid_generate_v4()");
            builder
                .HasOne(r => r.User);
        }
    }
}