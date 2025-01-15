using System.ComponentModel.DataAnnotations;

namespace EmployeeManageApi.Models.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string? LastName { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [MaxLength(250)]
        public string? Email { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}
