using Microsoft.EntityFrameworkCore;

namespace EFCoreDataAccess.Data
{
    public class EFCoreProjectDbContext : DbContext
    {
        public EFCoreProjectDbContext(DbContextOptions<EFCoreProjectDbContext> options) : base(options)
        {

        }


    }
}
