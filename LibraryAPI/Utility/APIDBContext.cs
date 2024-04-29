using LibraryAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Utility
{
    public class APIDBContext : DbContext
    {
        public APIDBContext(DbContextOptions<APIDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<BorrowedBooks> BorrowedBooks { get; set; }
    }
}
