using PayTrack.Models;

namespace PayTrack.Repository
{
    public interface IPayrollRepository
    {
        Task<IEnumerable<Payroll>> GetAllPayrollsAsync(CancellationToken cancellationToken);
        Task<Payroll> GetPayrollByIdAsync(int id, CancellationToken cancellationToken);
        Task<Payroll> AddPayrollAsync(Payroll payroll, CancellationToken cancellationToken);
        Task<Payroll> UpdatePayrollAsync(Payroll payroll, CancellationToken cancellationToken);
        Task<Payroll> DeletePayrollAsync(int id, CancellationToken cancellationToken);
    }
}
