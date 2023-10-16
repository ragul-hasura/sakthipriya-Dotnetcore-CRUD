using Microsoft.EntityFrameworkCore;

namespace SimpleEmpCRUDAJAX.Models
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<EmployeeDetails> _employees { get; set; }

    }
}
