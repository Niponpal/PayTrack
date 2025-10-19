using PayTrack.Models;

namespace PayTrack.Repository
{
    public interface ISalaryComponentRepository
    {
        Task<IEnumerable<SalaryComponent>> GetSalaryComponentsAsync(CancellationToken cancellationToken);
        Task<SalaryComponent> GetSalaryComponentByIdAsync(int id,CancellationToken cancellationToken);
        Task<SalaryComponent> AddSalaryComponentAsync(SalaryComponent component,CancellationToken cancellationToken);
        Task<SalaryComponent> UpdateSalaryComponentAsync(SalaryComponent component,CancellationToken cancellationToken);
        Task<SalaryComponent> DeleteSalaryComponentAsync(int id,CancellationToken cancellationToken);
    }
}
