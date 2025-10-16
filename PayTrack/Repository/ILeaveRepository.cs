using PayTrack.Models;

namespace PayTrack.Repository
{
    public interface ILeaveRepository
    {
        Task<IEnumerable<Leave>> GetAllLeaveAsynce(CancellationToken cancellationToken);
        Task<Leave?> GetLeaveByIdAsync(int id, CancellationToken cancellationToken);
        Task<Leave> AddLeaveAsync(Leave leave, CancellationToken cancellationToken);
        Task<Leave?> UpdateLeaveAsync( Leave leave, CancellationToken cancellationToken);
        Task<Leave?> DeleteLeaveAsync(int id, CancellationToken cancellationToken);

    }
}
