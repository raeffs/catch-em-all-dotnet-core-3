using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raefftec.CatchEmAll.Entities;

namespace Raefftec.CatchEmAll
{
    public interface IDbContext : IDisposable
    {
        public DbSet<UserReference> UserReferences { get; }

        public DbSet<SearchQuery> SearchQueries { get; }

        public DbSet<SearchResult> SearchResults { get; }

        public DbSet<Article> Articles { get; }

        public Task SaveAsync();
    }
}
