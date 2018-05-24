using Com.Moonlay.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Configs;

namespace Com.Danliris.Service.Merchandiser.Lib
{
    public class MerchandiserDbContext : BaseDbContext
    {
        public MerchandiserDbContext(DbContextOptions<MerchandiserDbContext> options) : base(options)
        {
        }

        public DbSet<Size> Sizes { get; set; }
        public DbSet<Rate> Rates { get; set; }

        public DbSet<Efficiency> Efficiencies { get; set; }
        public DbSet<SizeRange> SizeRanges { get; set; }
        public DbSet<RelatedSize> RelatedSizes { get; set; }

        public DbSet<CostCalculationGarment> CostCalculationGarments { get; set; }
        public DbSet<CostCalculationGarment_Material> CostCalculationGarment_Materials { get; set; }
        public DbSet<Line> Lines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SizeConfig());
            modelBuilder.ApplyConfiguration(new RateConfig());

            modelBuilder.ApplyConfiguration(new EfficiencyConfig());
            modelBuilder.ApplyConfiguration(new SizeRangeConfig());
            modelBuilder.ApplyConfiguration(new RelatedSizeConfig());

            modelBuilder.ApplyConfiguration(new CostCalculationGarmentConfig());
            modelBuilder.ApplyConfiguration(new CostCalculationGarment_MaterialConfig());

            modelBuilder.ApplyConfiguration(new LineConfig());
        }
    }
}