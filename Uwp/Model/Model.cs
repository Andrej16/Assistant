using Microsoft.EntityFrameworkCore;

namespace Uwp.Model
{
    public class Context : DbContext
    {
        public DbSet<IdentRisk> IdentRisks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"Data Source=dboracledev.ingo.office:1521/insbcp;Persist Security Info=True;User ID=INSURADM;Password=AisIngo");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "INSURADM");
            modelBuilder.ApplyConfiguration(new IdentRiskConfiguration());
        }
    }
    public class IdentRisk
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
