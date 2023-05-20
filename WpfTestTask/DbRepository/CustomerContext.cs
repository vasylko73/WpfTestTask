using Microsoft.EntityFrameworkCore;
using WpfApp2.Model;

namespace WpfApp2.DbRepository
{
    class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER02;Database=CustomerDb;Trusted_Connection=True;TrustServerCertificate=True;");

        }
    }
}
