using EFCoreDataAccess.Data.FluentConfiguration;
using EFCoreModels.Models;
using EFCoreModels.Models.FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDataAccess.Data
{
    public class EFCoreProjectDbContext : DbContext
    {
        public EFCoreProjectDbContext(DbContextOptions<EFCoreProjectDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FluentBookConfiguration());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfiguration());
            modelBuilder.ApplyConfiguration(new FluentAuthorConfiguration());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfiguration());
            modelBuilder.ApplyConfiguration(new FluentAuthorBookConfiguration());
        }

        DbSet<FluentBookDetail> FluentBookDetails { get; set; }

        DbSet<FluentBook> FluentBooks { get; set; }

        DbSet<FluentAuthor> FluentAuthors { get; set; }

        DbSet<FluentPublisher> FluentPublishers { get; set; }
    }
}
