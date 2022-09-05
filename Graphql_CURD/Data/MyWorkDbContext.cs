using Microsoft.EntityFrameworkCore;

namespace Graphql_CURD.Data
{
    public class MyWorkDbContext : DbContext
    {
        public MyWorkDbContext(DbContextOptions<MyWorkDbContext> options) : base(options)
        {
        }
        public DbSet<Cakes> Cakes {get; set;}
    }
}
