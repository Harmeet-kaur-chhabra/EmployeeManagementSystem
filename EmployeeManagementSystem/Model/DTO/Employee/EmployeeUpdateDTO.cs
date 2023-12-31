﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Model.DTO.Employee
{
    public class EmployeeUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int DesignationId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Qualification { get; set; }

    }
}
