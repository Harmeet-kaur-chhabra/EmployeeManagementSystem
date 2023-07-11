using EmployeeManagementSystem.Model.DTO.User;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Model.DTO;

namespace EmployeeManagementSystem.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        bool IsUniqueUser(string userName);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        
        Task<User> Register(UserCreateDTO userCreateDTO);
        Task<User> UpdateAsync(User entity);

    }
}
