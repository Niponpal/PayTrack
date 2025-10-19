using Microsoft.AspNetCore.Mvc;
using PayTrack.Data;
using PayTrack.Models;
using PayTrack.Repository;
using System.Threading.Tasks;

namespace PayTrack.Controllers
{
    public class SalaryComponentController : Controller
    {
        private readonly ISalaryComponentRepository _salaryComponentRepository;

        public SalaryComponentController(ISalaryComponentRepository salaryComponentRepository)
        {
            _salaryComponentRepository = salaryComponentRepository;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _salaryComponentRepository.GetSalaryComponentsAsync(cancellationToken);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return View(new SalaryComponent());
            }
            var data = await _salaryComponentRepository.GetSalaryComponentByIdAsync(id, cancellationToken);
            if (data != null)
            {
                return View(data);
            }
           return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(SalaryComponent salaryComponent, CancellationToken cancellationToken)
        {
           if(salaryComponent.ID == 0)
            {
                await _salaryComponentRepository.AddSalaryComponentAsync(salaryComponent, cancellationToken);
                return RedirectToAction("Index");
            }
           else
            {
                await _salaryComponentRepository.UpdateSalaryComponentAsync(salaryComponent, cancellationToken);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var data = await _salaryComponentRepository.GetSalaryComponentByIdAsync(id, cancellationToken);
            if (data != null)
            {
                return View(data);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _salaryComponentRepository.DeleteSalaryComponentAsync(id, cancellationToken);
            return RedirectToAction("Index");
        }
    }
}
