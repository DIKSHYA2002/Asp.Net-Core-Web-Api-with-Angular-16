using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Data
{
    public class AppDbContext : DbContext
    {
        //constructor for the DbContext Class
        //DbContextOptions<ApplicationDbContext> parameter. This is how context configuration from AddDbContext is passed to the DbContext
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
