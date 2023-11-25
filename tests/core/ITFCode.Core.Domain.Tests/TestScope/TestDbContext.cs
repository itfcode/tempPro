using Microsoft.EntityFrameworkCore;

namespace ITFCode.Core.Domain.Tests.TestScope
{
    public class TestDbContext : DbContext
    {
        public DbSet<EntityWithSimpleKey> TestEntities { get; set; }

        public DbSet<EntityWithComplexKey> TestEntitiesWithComplexKey { get; set; }

        public TestDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityWithSimpleKey>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<EntityWithComplexKey>()
                .HasKey(d => new { d.Key1, d.Key2 });
        }
    }
}