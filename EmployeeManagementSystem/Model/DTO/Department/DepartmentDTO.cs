﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Model.DTO.Department
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string DepartmentCode { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only Alphabets  allowed.")]
        public string DepartmentName { get; set; }
    }
}
