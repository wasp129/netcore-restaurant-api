using Microsoft.EntityFrameworkCore;
using SundownBoulevard.Data;
using SundownBoulevard.Data.Reservation;
using SundownBoulevard.Data.Table;
using SundownBoulevard.Models.User;
using SundownBoulevard.Models.Reservation;
using SundownBoulevard.Models.Table;

namespace SundownBoulevard
{
    public class SundownBoulevardContext : DbContext
    {
        public SundownBoulevardContext(DbContextOptions<SundownBoulevardContext> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.HasPostgresExtension("uuid-ossp");

            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new ReservationConfig());
            builder.ApplyConfiguration(new TableConfig());
            
            base.OnModelCreating(builder);
            
        }
        
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }
        public DbSet<TableModel> Tables { get; set; }
    }
}