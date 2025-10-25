using Microsoft.AspNetCore.Mvc;
using PayTrack.Models;
using PayTrack.Repository;
using System.Diagnostics;

namespace PayTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHRNoticeRepository _hRNoticeRepository;
        private readonly IEmployeeRepostory _employeeRepostory;

        public HomeController(ILogger<HomeController> logger, IHRNoticeRepository hRNoticeRepository, IEmployeeRepostory employeeRepostory)
        {
            _logger = logger;
            _hRNoticeRepository = hRNoticeRepository;
            _employeeRepostory = employeeRepostory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> Notice(CancellationToken cancellationToken)
        {
           
            var notices = await _hRNoticeRepository.GetAllHRNoticesAsync(cancellationToken);

            return View(notices);
        }

        public async Task<IActionResult> EmployeList(CancellationToken cancellationToken)
        {
            // ?? Employee + ????? Designation ???
            var employees = await _employeeRepostory.GetAllEmployeeAsynce(cancellationToken);

            // View-? ??????
            return View(employees);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
