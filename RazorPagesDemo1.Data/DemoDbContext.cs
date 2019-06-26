using Microsoft.EntityFrameworkCore;
using RazorPagesDemo1.Core;

namespace RazorPagesDemo1.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        {
        
        }
        public DbSet<Restaurant> Restaurants { get; set; }


    }

    
}
