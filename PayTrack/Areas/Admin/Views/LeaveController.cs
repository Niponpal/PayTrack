using Microsoft.AspNetCore.Mvc;
using PayTrack.Models;
using PayTrack.Repository;
using System.Threading.Tasks;

namespace PayTrack.Areas.Admin.Views
{
    [Area("Admin")]
    public class LeaveController : Controller
    {
        private readonly ILeaveRepository _leaveRepository;
        public LeaveController(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _leaveRepository.GetAllLeaveAsynce(cancellationToken);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
               return View(new Leave());
            }
            var data = await _leaveRepository.GetLeaveByIdAsync(id, cancellationToken);
            if(data != null)
            {
                return View(data);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Leave leave, CancellationToken cancellationToken)
        {
            if(leave.ID == 0)
            {
                await _leaveRepository.AddLeaveAsync(leave, cancellationToken);
                return RedirectToAction("Index");
            }
            else
            {
                var data = await _leaveRepository.UpdateLeaveAsync( leave, cancellationToken);
                if(data != null)
                {
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var data = await _leaveRepository.GetLeaveByIdAsync(id, cancellationToken);
            if(data != null)
            {
                return View(data);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var data = await _leaveRepository.DeleteLeaveAsync(id, cancellationToken);
            if(data != null)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
