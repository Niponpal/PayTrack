using PayTrack.Models;

namespace PayTrack.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync(CancellationToken cancellationToken);
        Task<Department> GetDepartmentByIdAsync(int id, CancellationToken cancellationToken);
        Task<Department> AddDepartmentAsync(Department department, CancellationToken cancellationToken);
        Task<Department> UpdateDepartmentAsync(Department department, CancellationToken cancellationToken);
        Task<Department> DeleteDepartmentAsync(int id, CancellationToken cancellationToken);

    }
}
