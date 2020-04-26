using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raefftec.CatchEmAll.Entities;

namespace Raefftec.CatchEmAll
{
    internal class Context : DbContext, IDbContext
    {
        public DbSet<UserReference> UserReferences { get; set; } = null!;

        public DbSet<SearchQuery> SearchQueries { get; set; } = null!;

        public DbSet<SearchResult> SearchResults { get; set; } = null!;

        public DbSet<Article> Articles { get; set; } = null!;

        public Context(DbContextOptions options)
            : base(options)
        {
        }

        public Task SaveAsync()
        {
            return this.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.BuildModel(modelBuilder);
            this.ApplyGlobalModifications(modelBuilder);
        }

        private void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserReference>();

            modelBuilder.Entity<SearchQuery>();

            modelBuilder.Entity<SearchResult>();

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasIndex(x => x.ExternalId).IsUnique();
            });
        }

        private void ApplyGlobalModifications(ModelBuilder modelBuilder)
        {
            var decimalProperties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties())
                .Where(x => x.ClrType == typeof(decimal) || x.ClrType == typeof(decimal?));

            foreach (var property in decimalProperties)
            {
                property.SetColumnType("decimal(18, 6)");
            }
        }
    }
}
