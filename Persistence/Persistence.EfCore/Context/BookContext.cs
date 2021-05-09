using BookCatalog.Domain.Entities;
using BookCatalog.MicroService.Infra.Persistence.EfCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.MicroService.Infra.Persistence.EfCore.Context
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
