using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Repository.IRepository
{
    public interface IDesignationRepository : IRepository<Designation>
    {
        Task<Designation> UpdateAsync(Designation entity);
    }
}
