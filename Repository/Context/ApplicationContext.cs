using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientServices> ClientServices { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Service> Services { get; set; }

        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
