using EmployeeManageApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManageApi.Models.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Employee> Employees { get; set; }
    }
}
