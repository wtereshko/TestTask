using System.Data.Entity;

namespace TestTask.Models
{
    public class DBContext : DbContext

    {
        public DBContext()
       : base("DataBaseConnection")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}
