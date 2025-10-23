using Microsoft.AspNetCore.Mvc;
using PayTrack.Models;
using PayTrack.Repository;
using System.Threading.Tasks;

namespace PayTrack.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HRNoticeController : Controller
    {      
        private readonly IHRNoticeRepository _hRNoticeRepository;
        public HRNoticeController(IHRNoticeRepository hRNoticeRepository)
        {
            _hRNoticeRepository = hRNoticeRepository;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _hRNoticeRepository.GetAllHRNoticesAsync(cancellationToken);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if(id == 0)
            {
                return View(new HRNotice());
            }
            else
            {
                var data = await _hRNoticeRepository.GetHRNoticeByIdAsync(id, cancellationToken);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(HRNotice hRNotice, CancellationToken cancellationToken)
        {
                if (hRNotice.ID == 0)
                {
                    await _hRNoticeRepository.AddHRNoticeAsync(hRNotice, cancellationToken);
                    return RedirectToAction("Index");
                }
                else
                {
                    await _hRNoticeRepository.UpdateHRNoticeAsync(hRNotice, cancellationToken);
                    return RedirectToAction("Index");
                }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var data = await _hRNoticeRepository.DeleteHRNoticeAsync(id, cancellationToken);
           if(data != null)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var data = await _hRNoticeRepository.GetHRNoticeByIdAsync(id, cancellationToken);
            if(data != null)
            {
                return View(data);
            }
            return NotFound();
        }

    }
}
