using PayTrack.Models;

namespace PayTrack.Repository
{
    public interface IHRNoticeRepository
    {
           Task<IEnumerable<HRNotice>> GetAllHRNoticesAsync(CancellationToken cancellationToken);
            Task<HRNotice> GetHRNoticeByIdAsync(int id, CancellationToken cancellationToken);
            Task<HRNotice> AddHRNoticeAsync(HRNotice hRNotice, CancellationToken cancellationToken);
            Task<HRNotice> UpdateHRNoticeAsync(HRNotice hRNotice, CancellationToken cancellationToken);
            Task<HRNotice> DeleteHRNoticeAsync(int id, CancellationToken cancellationToken);
    }
}
