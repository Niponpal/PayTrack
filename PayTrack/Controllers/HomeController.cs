using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayTrack.Models;
using PayTrack.Repository;

namespace PayTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHRNoticeRepository _hRNoticeRepository;

      

        public HomeController(ILogger<HomeController> logger, IHRNoticeRepository hRNoticeRepository)
        {
            _logger = logger;
            _hRNoticeRepository = hRNoticeRepository;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
