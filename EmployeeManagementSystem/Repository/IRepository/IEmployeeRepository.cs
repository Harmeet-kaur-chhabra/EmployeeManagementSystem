using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> UpdateAsync(Employee entity);
    }
}
