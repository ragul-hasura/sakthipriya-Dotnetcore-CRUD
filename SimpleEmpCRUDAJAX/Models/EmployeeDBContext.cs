using Microsoft.EntityFrameworkCore;

namespace SimpleEmpCRUDAJAX.Models
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {

        }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }

    }
}
