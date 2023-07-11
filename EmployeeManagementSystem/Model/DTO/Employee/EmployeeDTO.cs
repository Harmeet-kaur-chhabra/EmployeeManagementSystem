using EmployeeManagementSystem.Model.DTO.Department;
using EmployeeManagementSystem.Model.DTO.Designation;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Model.DTO.Employee
{
    public class EmployeeDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int DesignationId { get; set; }
        public DesignationDTO designation { get; set; }

        [Required]
        public int DepartmentId { get; set; }             
        public DepartmentDTO department { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Qualification { get; set; }


    }
}
