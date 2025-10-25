using Microsoft.AspNetCore.Mvc.Rendering;
using PayTrack.Models;

namespace PayTrack.Repository
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<Designation>> GetAllDesignationsAsync(CancellationToken cancellationToken);
        Task<Designation> GetDesignationByIdAsync(int id, CancellationToken cancellationToken);
        Task<Designation> AddDesignationAsync(Designation designation, CancellationToken cancellationToken);
        Task<Designation> UpdateDesignationAsync(Designation designation, CancellationToken cancellationToken);
        Task<Designation> DeleteDesignationAsync(int id, CancellationToken cancellationToken);

        IEnumerable<SelectListItem> Dropdown();
    }
}
