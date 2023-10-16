using System.ComponentModel.DataAnnotations;

namespace SimpleEmpCRUDAJAX.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        public string Name { get; set; }        
        public int Age { get; set; }        
        public string State { get; set; }       
        public string Country { get; set; }
        public decimal Salary { get; set; }


    }
}
