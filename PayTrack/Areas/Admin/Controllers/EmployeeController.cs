using Microsoft.AspNetCore.Mvc;
using PayTrack.Models;
using PayTrack.Repository;
using System.Threading.Tasks;

namespace PayTrack.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepostory _employeeRepostory;
        private readonly IDesignationRepository _designationRepository;
      
        public EmployeeController(IEmployeeRepostory employeeRepostory, IDesignationRepository designationRepository)
        {
            _employeeRepostory = employeeRepostory;
            _designationRepository = designationRepository;
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
                ViewData["DesignationID"] = _designationRepository.Dropdown();
                return View(new Employee());
            }
            else
            {
                var employee = await _employeeRepostory.GetEmployeeByIdAsync(id, cancellationToken);
                if (employee == null)
                {
                    return NotFound();
                }
                ViewData["DesignationID"] = _designationRepository.Dropdown();
                return View(employee);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Employee employee, CancellationToken cancellationToken)
        {
            if (employee.ID == 0)
            {
                ViewData["DesignationID"] = _designationRepository.Dropdown();
                await _employeeRepostory.AddEmployeeAsync(employee, cancellationToken);
                return RedirectToAction(nameof(Index));

            }
            else
            {
                ViewData["DesignationID"] = _designationRepository.Dropdown();
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
