using Microsoft.EntityFrameworkCore;
using PayTrack.Data;
using PayTrack.Models;

namespace PayTrack.Repository
{
    public class HRNoticeRepository : IHRNoticeRepository
    {
        private readonly ApplicationDbContext _context;
        public HRNoticeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<HRNotice> AddHRNoticeAsync(HRNotice hRNotice, CancellationToken cancellationToken)
        {
            await _context.HRNotices.AddAsync(hRNotice, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return hRNotice;
        }

        public async Task<HRNotice> DeleteHRNoticeAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.HRNotices.FindAsync(id, cancellationToken);
            if (data != null)
            {
                _context.HRNotices.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null!;
        }

        public async Task<IEnumerable<HRNotice>> GetAllHRNoticesAsync(CancellationToken cancellationToken)
        {
            var data = await _context.HRNotices.ToListAsync(cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<HRNotice> GetHRNoticeByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.HRNotices.FindAsync(id, cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null!;
        }



        public async Task<HRNotice> UpdateHRNoticeAsync(HRNotice hRNotice, CancellationToken cancellationToken)
        {
            var data = await _context.HRNotices.FindAsync(hRNotice.ID, cancellationToken);
            if (data != null)
            {
                data.Title = hRNotice.Title;
                data.Description = hRNotice.Description;
                data.IssuedBy = hRNotice.IssuedBy;
                data.TargetGroup = hRNotice.TargetGroup;
                data.PublishedDate = hRNotice.PublishedDate;
                data.ExpiryDate = hRNotice.ExpiryDate;
                data.IsImportant = hRNotice.IsImportant;
                data.AttachmentUrl = hRNotice.AttachmentUrl;
                data.Status = hRNotice.Status;
                data.IsApproved = hRNotice.IsApproved;
                _context.HRNotices.Update(data);
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            else
            {
                return null!;
            }
        }
    }
}
