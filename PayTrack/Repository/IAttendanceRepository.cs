using PayTrack.Models;

namespace PayTrack.Repository
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllAttendancesAsync(CancellationToken cancellationToken);
        Task<Attendance> GetAttendanceByIdAsync(int id, CancellationToken cancellationToken);
        Task<Attendance> GetAddAsynce(Attendance attendance, CancellationToken cancellationToken);
        Task<Attendance> GetByUpdateAsynce(Attendance attendance, CancellationToken cancellationToken);
        Task<Attendance> GetDeleteByAsynce(int id, CancellationToken cancellationToken);
    }
}
