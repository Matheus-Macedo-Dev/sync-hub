using Microsoft.EntityFrameworkCore;
using SyncHub.Domain.Entities;

namespace SyncHub.Infrastructure.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Card>()
                 .HasKey(c => c.Id);


            modelBuilder.Entity<Deck>()
                .HasMany(c => c.Cards)
                .WithOne(d => d.Deck)
                .HasForeignKey(c => c.DeckId);


        }
    }
}
