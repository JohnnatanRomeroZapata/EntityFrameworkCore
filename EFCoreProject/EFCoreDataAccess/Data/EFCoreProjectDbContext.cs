using EFCoreModels.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDataAccess.Data
{
    public class EFCoreProjectDbContext : DbContext
    {
        public EFCoreProjectDbContext(DbContextOptions<EFCoreProjectDbContext> options) : base(options)
        {

        }

        DbSet<Category> Categories { get; set; }

        DbSet<Gender> Genders { get; set; }

        DbSet<Book> Books { get; set; }

        DbSet<Author> Authors { get; set; }

        DbSet<Publisher> Publishers { get; set; }
    }
}
