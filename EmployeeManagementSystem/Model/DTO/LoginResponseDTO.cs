using EmployeeManagementSystem.Model.DTO.User;

namespace EmployeeManagementSystem.Model.DTO
{
    public class LoginResponseDTO
    {
        public UserDTO user { get; set; }
        public string Token { get; set; }
    }
}
