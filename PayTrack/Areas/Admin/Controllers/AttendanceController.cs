using Microsoft.AspNetCore.Mvc;
using PayTrack.Models;
using PayTrack.Repository;
using System.Threading.Tasks;

namespace PayTrack.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
       
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceController(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _attendanceRepository.GetAllAttendancesAsync(cancellationToken);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if (id == 0|| id== null)
            {
                return View(new Attendance());
            }
            var data = await _attendanceRepository.GetAttendanceByIdAsync(id, cancellationToken);

            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Attendance attendance, CancellationToken cancellationToken)
        {
            var data = await _attendanceRepository.GetAttendanceByIdAsync(attendance.ID, cancellationToken);
             if(data== null)
            {
                await _attendanceRepository.GetAddAsynce(attendance, cancellationToken);
                return RedirectToAction("Index");
            }
            else
            {
                await _attendanceRepository.GetByUpdateAsynce(attendance, cancellationToken);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var data = await _attendanceRepository.GetAttendanceByIdAsync(id, cancellationToken);
            if(data != null)
            {
                return View(data);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var data = await _attendanceRepository.GetDeleteByAsynce(id, cancellationToken);
            if (data == null)
            {
                return NotFound();
              
            }
            return RedirectToAction("Index");
        }

    }
}
