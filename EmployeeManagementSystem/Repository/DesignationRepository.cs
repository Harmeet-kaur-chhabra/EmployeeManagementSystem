using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repository.IRepository;

namespace EmployeeManagementSystem.Repository
{
    public class DesignationRepository : Repository<Designation>, IDesignationRepository
    {
        private readonly ApplicationDbContext _db;
        public DesignationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Designation> UpdateAsync(Designation entity)
        {

            _db.designations.Update(entity);
            await _db.SaveChangesAsync();
            return entity;

        }
    }
}
