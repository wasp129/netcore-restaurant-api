using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SundownBoulevard.Models.Table;

namespace SundownBoulevard.Data.Table
{
    public class TableConfig : IEntityTypeConfiguration<TableModel>
    {
        public void Configure(EntityTypeBuilder<TableModel> builder)
        {
            builder
                .Property(p => p.Id)
                .HasDefaultValueSql("uuid_generate_v4()");
            builder
                .HasOne(t => t.Reservation);
        }
    }
}