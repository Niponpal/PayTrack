using Microsoft.EntityFrameworkCore;
using PayTrack.Data;
using PayTrack.Models;

namespace PayTrack.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
     
        private readonly ApplicationDbContext _applicationDbContext;
        public DepartmentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Department> AddDepartmentAsync(Department department, CancellationToken cancellationToken)
        {
             await _applicationDbContext.Departments.AddAsync(department, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return department;
        }

        public async Task<Department> DeleteDepartmentAsync(int id, CancellationToken cancellationToken)
        {
           var data = await _applicationDbContext.Departments.FindAsync(id, cancellationToken);
            if(data== null)
            {
                return null;
            }
            _applicationDbContext.Departments.Remove(data);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return data;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync(CancellationToken cancellationToken)
        {
            var data = await _applicationDbContext.Departments.ToListAsync(cancellationToken);
            if(data== null)
            {
                return null;
            }
            return data;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _applicationDbContext.Departments.FindAsync(id, cancellationToken);
            if(data== null)
            {
                return null;
            }
            return data;
        }

        public async Task<Department> UpdateDepartmentAsync(Department department, CancellationToken cancellationToken)
        {
            var data = await _applicationDbContext.Departments.FindAsync(department.ID, cancellationToken);
            if(data== null)
            {
                return null;
            }
            data.DepartmentName= department.DepartmentName;
            data.Description= department.Description;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return data;

        }
    }
}
