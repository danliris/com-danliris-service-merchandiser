using Com.Moonlay.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Configs;
using Com.Moonlay.Data.EntityFrameworkCore;

namespace Com.Danliris.Service.Merchandiser.Lib
{
    
    //     public class MerchandiserDbContext : BaseDbContext
    public class MerchandiserDbContext : StandardDbContext
    {
     

        public MerchandiserDbContext(DbContextOptions<MerchandiserDbContext> options) : base(options)
        {
        }

        public DbSet<Rate> Rates { get; set; }
        public DbSet<Efficiency> Efficiencies { get; set; }
        public DbSet<CostCalculationGarment> CostCalculationGarments { get; set; }
        public DbSet<CostCalculationGarment_Material> CostCalculationGarment_Materials { get; set; }
        public DbSet<Line> Lines { get; set; }

        public DbSet<ArticleColor> ArticleColors { get; set; }
        public DbSet<RO_Garment> RO_Garments { get; set; }
        public DbSet<RO_Garment_SizeBreakdown> RO_Garment_SizeBreakdowns { get; set; }
        public DbSet<RO_Garment_SizeBreakdown_Detail> RO_Garment_SizeBreakdown_Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RateConfig());

            modelBuilder.ApplyConfiguration(new EfficiencyConfig());

            modelBuilder.ApplyConfiguration(new CostCalculationGarmentConfig());
            modelBuilder.ApplyConfiguration(new CostCalculationGarment_MaterialConfig());

            modelBuilder.ApplyConfiguration(new LineConfig());

            modelBuilder.ApplyConfiguration(new RO_GarmentConfig());
            modelBuilder.ApplyConfiguration(new RO_Garment_SizeBreakdownConfig());
            modelBuilder.ApplyConfiguration(new RO_Garment_SizeBreakdown_DetailConfig());
        }
    }
}