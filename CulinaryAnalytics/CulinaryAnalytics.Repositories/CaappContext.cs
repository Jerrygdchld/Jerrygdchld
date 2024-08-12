using CulinaryAnalytics.Models.Entities.Common;
using CulinaryAnalytics.Models.Entities.StoreFront;
using System.Reflection;

namespace CulinaryAnalytics.Repositories
{
    public class CaappContext(DbContextOptions<CaappContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<DictionaryList> Dictionaries { get; set; }
        public DbSet<DictionaryListItem> DictionaryEntries { get; set; }

        #region StoreFront
        public DbSet<Recipe> Recipes { get; set; }
        #endregion
    }
}
