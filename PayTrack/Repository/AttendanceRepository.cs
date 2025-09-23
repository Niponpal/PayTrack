using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PayTrack.Data;
using WebApplication1.Models;

namespace PayTrack.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public AttendanceRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<Attendance> GetAddAsynce(Attendance attendance, CancellationToken cancellationToken)
        {
            await _applicationDbContext.Attendances.AddAsync(attendance, cancellationToken);
            await  _applicationDbContext.SaveChangesAsync();
            return attendance;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync(CancellationToken cancellationToken)
        {
            var data = await _applicationDbContext.Attendances.ToListAsync();
            if(data== null)
            {
                return null;
            }
            return data;
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _applicationDbContext.Attendances.FindAsync(id, cancellationToken);
            if(data== null)
            {
                return null;
            }
            return data;
        }

        public async Task<Attendance> GetByUpdateAsynce(Attendance attendance, CancellationToken cancellationToken)
        {
           var data = await _applicationDbContext.Attendances.FindAsync(attendance, cancellationToken);
            if( data != null)
            {
                _mapper.Map(attendance, data);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
        public async Task<Attendance> GetDeleteByAsynce(int id, CancellationToken cancellationToken)
        {
            var data = await _applicationDbContext.Attendances.FindAsync(id, cancellationToken);
            if(data== null)
            {
                return null;
            }
            return data;
        }
    }
}
