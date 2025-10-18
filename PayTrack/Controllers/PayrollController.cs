using Microsoft.AspNetCore.Mvc;
using PayTrack.Models;
using PayTrack.Repository;
using System.Threading.Tasks;

namespace PayTrack.Controllers
{
    public class PayrollController : Controller
    {
        private readonly IPayrollRepository _payrollRepository;
        public PayrollController(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _payrollRepository.GetAllPayrollsAsync(cancellationToken);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return View(new Payroll());
            }
            var data = await _payrollRepository.GetPayrollByIdAsync(id, cancellationToken);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Payroll payroll, CancellationToken cancellationToken)
        {
            if (payroll.ID == 0)
            {
                await _payrollRepository.AddPayrollAsync(payroll, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            await _payrollRepository.UpdatePayrollAsync(payroll, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var data = await _payrollRepository.GetPayrollByIdAsync(id, cancellationToken);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var data = await _payrollRepository.DeletePayrollAsync(id, cancellationToken);
            if (data == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
