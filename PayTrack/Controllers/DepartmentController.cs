using Microsoft.AspNetCore.Mvc;
using PayTrack.Models;
using PayTrack.Repository;

namespace PayTrack.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _departmentRepository.GetAllDepartmentsAsync(CancellationToken.None);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if (id == 0 || id == null)
            {
                return View(new Department());
            }
            else
            {
                var department = await _departmentRepository.GetDepartmentByIdAsync(id, cancellationToken);
                if (department == null)
                {
                    return NotFound();
                }
                return View(department);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Department department, CancellationToken cancellationToken)
        {
            if (department.ID == 0)
            {
                var data = await _departmentRepository.AddDepartmentAsync(department, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var data = await _departmentRepository.UpdateDepartmentAsync(department, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.DeleteDepartmentAsync(id, cancellationToken);
            if (department == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id, cancellationToken);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);

        }
    }
}
