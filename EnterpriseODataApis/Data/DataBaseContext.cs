using EnterpriseODataApis.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseODataApis.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
