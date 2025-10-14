using Microsoft.AspNetCore.Mvc;
using PayTrack.Models;
using PayTrack.Repository;
using System.Threading.Tasks;

namespace PayTrack.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepostory _employeeRepostory;
        public EmployeeController(IEmployeeRepostory employeeRepostory)
        {
            _employeeRepostory = employeeRepostory;
        }
        public async Task<IActionResult> Index( CancellationToken cancellationToken)
        {
            var employess = await _employeeRepostory.GetAllEmployeeAsynce(cancellationToken);
            return View(employess);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id,CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return View(new Employee());
            }
            else
            {
                var employee = await _employeeRepostory.GetEmployeeByIdAsync(id, cancellationToken);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Employee employee, CancellationToken cancellationToken)
        {
            if (employee.ID == 0)
            {
                var employeeData = await _employeeRepostory.AddEmployeeAsync(employee, cancellationToken);
                return RedirectToAction(nameof(Index));

            }
            else
            {
                var employeeData = await _employeeRepostory.UpdateEmployeeAsync(employee, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var data = await _employeeRepostory.GetEmployeeByIdAsync(id, cancellationToken);
            if (data != null)
            {
                return View(data);
            }
            return NotFound(); 
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var data = await _employeeRepostory.DeleteEmployeeAsync(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
}
