using PayTrack.Models;

namespace PayTrack.Repository
{
    public interface IEmployeeRepostory
    {
        Task<IEnumerable<Employee>> GetAllEmployeeAsynce(CancellationToken cancellationToken);
        Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken cancellationToken);
        Task<Employee> AddEmployeeAsync(Employee employee, CancellationToken cancellationToken);
        Task<Employee> UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
        Task<Employee> DeleteEmployeeAsync(int id, CancellationToken cancellationToken);
    }
}
