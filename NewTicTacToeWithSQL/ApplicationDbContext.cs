using Microsoft.EntityFrameworkCore;
using NewTicTacToeWithSQL.Entities;

namespace NewTicTacToeWithSQL
{
    internal class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database = TicTacToeDB; Integrated Security = true; TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.Name).HasMaxLength(50);
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<User> Users { get; set; }
    }
}