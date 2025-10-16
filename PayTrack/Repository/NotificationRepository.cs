using Microsoft.EntityFrameworkCore;
using PayTrack.Data;
using PayTrack.Models;

namespace PayTrack.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;
        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Notification> AddNotificationAsync(Notification notification, CancellationToken cancellationToken)
        {
            await _context.Notifications.AddAsync(notification, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return notification;
        }

        public async Task<Notification> DeleteNotificationAsync(int id, CancellationToken cancellationToken)
        {
          var data = await _context.Notifications.FindAsync(id,cancellationToken);
            if(data != null)
            {
                _context.Notifications.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync(CancellationToken cancellationToken)
        {
            var data = await _context.Notifications.ToListAsync(cancellationToken);
            if(data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Notification?> GetNotificationByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Notifications.FindAsync(id,cancellationToken);
            if(data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Notification> UpdateNotificationAsync(Notification notification, CancellationToken cancellationToken)
        {
           var data = await _context.Notifications.FindAsync(notification.ID,cancellationToken);
            if(data != null)
            {
                data.Message = notification.Message;
                data.Status = notification.Status;
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
