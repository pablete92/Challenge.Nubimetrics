using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Challenge.Nubimetrics.Domain.Contexts
{
    public class ChallengeDbContext : DbContext
    {
        public ChallengeDbContext() : base(new DbContextOptionsBuilder<ChallengeDbContext>().Options)
        { }

        public ChallengeDbContext(DbContextOptions<ChallengeDbContext> option)
            : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

        public bool Exists<TEntity>() where TEntity : class
        {
            var attachedEntity = ChangeTracker.Entries<TEntity>().FirstOrDefault();
            return (attachedEntity != null);
        }
    }
}
