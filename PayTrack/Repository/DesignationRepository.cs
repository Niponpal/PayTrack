using Microsoft.EntityFrameworkCore;
using PayTrack.Data;
using PayTrack.Models;

namespace PayTrack.Repository
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly ApplicationDbContext _context;
        public DesignationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Designation> AddDesignationAsync(Designation designation, CancellationToken cancellationToken)
        {
            await _context.Designations.AddAsync(designation, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return designation;
        }

        public async Task<Designation> DeleteDesignationAsync(int id, CancellationToken cancellationToken)
        {
           var data = await _context.Designations.FindAsync(id,cancellationToken);
            if (data != null)
            {
                _context.Designations.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null!;
        }

        public async Task<IEnumerable<Designation>> GetAllDesignationsAsync(CancellationToken cancellationToken)
        {
            var data = await _context.Designations.ToListAsync(cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null!;
        }

        public async Task<Designation> GetDesignationByIdAsync(int id, CancellationToken cancellationToken)
        {
           var data = await _context.Designations.FindAsync(id,cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null!;
        }

        public async Task<Designation> UpdateDesignationAsync(Designation designation, CancellationToken cancellationToken)
        {
           var data = await _context.Designations.FindAsync(designation.ID,cancellationToken);
            if (data != null)
            {
                data.DesignationName = designation.DesignationName;
                data.Level = designation.Level;
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null!;
        }
    }
}
