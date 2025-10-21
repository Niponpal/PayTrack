using Microsoft.AspNetCore.Mvc;
using PayTrack.Models;
using PayTrack.Repository;
using System.Threading.Tasks;

namespace PayTrack.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private INotificationRepository _notificationRepository;
        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _notificationRepository.GetAllNotificationsAsync(cancellationToken);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return View(new Notification());
            }
            else
            {
                var data = await _notificationRepository.GetNotificationByIdAsync(id, cancellationToken);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Notification notification, CancellationToken cancellationToken)
        {
           
                if (notification.ID == 0)
                {
                    await _notificationRepository.AddNotificationAsync(notification, cancellationToken);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    await _notificationRepository.UpdateNotificationAsync(notification, cancellationToken);
                    return RedirectToAction(nameof(Index));
                }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var data = await _notificationRepository.GetNotificationByIdAsync(id, cancellationToken);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken) 
        { 
          var data = await _notificationRepository.DeleteNotificationAsync(id, cancellationToken);
            if(data == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
