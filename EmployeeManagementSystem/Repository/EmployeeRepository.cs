using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repository.IRepository;

namespace EmployeeManagementSystem.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public async Task<Employee> UpdateAsync(Employee entity)
        {

            _db.employees.Update(entity);
            await _db.SaveChangesAsync();
            return entity;

        }
    }
}