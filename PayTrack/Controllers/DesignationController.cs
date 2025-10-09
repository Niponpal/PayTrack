using Microsoft.AspNetCore.Mvc;
using PayTrack.Models;
using PayTrack.Repository;
using System.Threading.Tasks;

namespace PayTrack.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IDesignationRepository _designationRepository;
        public DesignationController(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _designationRepository.GetAllDesignationsAsync(cancellationToken);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
           if(id==0 || id== null)
            {
                return View (new Designation());
            }
              else
                {
                 var designation = await _designationRepository.GetDesignationByIdAsync(id, cancellationToken);
                 if (designation == null)
                 {
                      return NotFound();
                 }
                 return View(designation);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit( Designation designation, CancellationToken cancellationToken)
        {
            if(designation.ID == 0)
            {
                var data = await _designationRepository.AddDesignationAsync(designation, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var data = await _designationRepository.UpdateDesignationAsync(designation, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var data = await _designationRepository.GetDesignationByIdAsync(id, cancellationToken);
            if(data != null)
            {
                return View(data);
            }
            return null;
        
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var data = await _designationRepository.DeleteDesignationAsync(id, cancellationToken);
            if (data == null)
            {
                return null;
            }
            return RedirectToAction("Index");

        }
    }
}
