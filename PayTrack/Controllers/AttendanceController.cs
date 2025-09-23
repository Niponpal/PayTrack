using Microsoft.AspNetCore.Mvc;
using PayTrack.Repository;
using System.Threading.Tasks;

namespace PayTrack.Controllers
{
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
    }
}
