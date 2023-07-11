using AutoMapper;
using EmployeeManagementSystem.Model.DTO.Department;
using EmployeeManagementSystem.Model.DTO.Designation;
using EmployeeManagementSystem.Model.DTO.Employee;
using EmployeeManagementSystem.Model.DTO.User;
using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
            CreateMap<Designation, DesignationDTO>().ReverseMap();
            CreateMap<Designation, DesignationCreateDTO>().ReverseMap();
            CreateMap<Designation, DesignationUpdateDTO>().ReverseMap();
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<Department, DepartmentCreateDTO>().ReverseMap();
            CreateMap<Department, DepartmentUpdateDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDTO>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDTO>().ReverseMap();

        }
    }
}
