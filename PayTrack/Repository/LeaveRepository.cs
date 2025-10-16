using Microsoft.EntityFrameworkCore;
using PayTrack.Data;
using PayTrack.Models;

namespace PayTrack.Repository
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LeaveRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Leave> AddLeaveAsync(Leave leave, CancellationToken cancellationToken)
        {
            await _dbContext.Leaves.AddAsync(leave, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return leave;
        }

        public async Task<Leave?> DeleteLeaveAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _dbContext.Leaves.FindAsync(id, cancellationToken);
            if (data != null)
            {
                _dbContext.Leaves.Remove(data);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }

        public async Task<IEnumerable<Leave>> GetAllLeaveAsynce(CancellationToken cancellationToken)
        {
            var data = await _dbContext.Leaves.ToListAsync(cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Leave?> GetLeaveByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _dbContext.Leaves.FindAsync(id, cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Leave?> UpdateLeaveAsync( Leave leave, CancellationToken cancellationToken)
        {
           var data = await _dbContext.Leaves.FindAsync(leave.ID, cancellationToken);
            if (data != null)
            {
                data.Status = leave.Status;
                data.EndDate = leave.EndDate;
                data.StartDate = leave.StartDate;
                data.LeaveType = leave.LeaveType;
                _dbContext.Leaves.Update(data);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }

      
    }
}
