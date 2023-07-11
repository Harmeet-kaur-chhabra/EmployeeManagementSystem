using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Repository.IRepository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department> UpdateAsync(Department entity);
    }
}
