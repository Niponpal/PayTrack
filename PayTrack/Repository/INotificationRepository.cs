using PayTrack.Models;

namespace PayTrack.Repository
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAllNotificationsAsync(CancellationToken cancellationToken);
        Task<Notification?> GetNotificationByIdAsync(int id, CancellationToken cancellationToken);
        Task<Notification> AddNotificationAsync(Notification notification, CancellationToken cancellationToken);
        Task<Notification> UpdateNotificationAsync(Notification notification, CancellationToken cancellationToken);
        Task<Notification> DeleteNotificationAsync(int id, CancellationToken cancellationToken);
    }
}
