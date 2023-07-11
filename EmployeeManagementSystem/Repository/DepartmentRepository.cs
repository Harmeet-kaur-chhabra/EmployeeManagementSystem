using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repository.IRepository;

namespace EmployeeManagementSystem.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Department> UpdateAsync(Department entity)
        {

            _db.departments.Update(entity);
            await _db.SaveChangesAsync();
            return entity;

        }

    }
}
