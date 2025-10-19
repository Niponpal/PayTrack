using Microsoft.EntityFrameworkCore;
using PayTrack.Data;
using PayTrack.Models;

namespace PayTrack.Repository
{
    public class SalaryComponentRepository : ISalaryComponentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SalaryComponentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<SalaryComponent> AddSalaryComponentAsync(SalaryComponent component, CancellationToken cancellationToken)
        {
           
            await _applicationDbContext.salaryComponents.AddAsync(component, cancellationToken);
            await  _applicationDbContext.SaveChangesAsync(cancellationToken);
            return component;
        }

        public async Task<SalaryComponent> DeleteSalaryComponentAsync(int id, CancellationToken cancellationToken)
        {
           var data = await _applicationDbContext.salaryComponents.FindAsync(id, cancellationToken);
            if (data != null)
            {
                _applicationDbContext.salaryComponents.Remove(data);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return data;
            }
                return null;    
        }

        public async Task<SalaryComponent> GetSalaryComponentByIdAsync(int id, CancellationToken cancellationToken)
        {
           var data = await _applicationDbContext.salaryComponents.FindAsync(id, cancellationToken);
          if(data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<IEnumerable<SalaryComponent>> GetSalaryComponentsAsync(CancellationToken cancellationToken)
        {
            var data = await _applicationDbContext.salaryComponents.ToListAsync(cancellationToken);
            if(data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<SalaryComponent> UpdateSalaryComponentAsync(SalaryComponent component, CancellationToken cancellationToken)
        {
           var data = await _applicationDbContext.salaryComponents.FindAsync(component.ID, cancellationToken);
            if(data != null)
            {
                data.ComponentName = component.ComponentName;
                data.Amount = component.Amount;
                _applicationDbContext.salaryComponents.Update(data);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
