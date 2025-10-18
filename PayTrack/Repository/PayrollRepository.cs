using Microsoft.EntityFrameworkCore;
using PayTrack.Data;
using PayTrack.Models;

namespace PayTrack.Repository
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly ApplicationDbContext _context;
        public PayrollRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Payroll> AddPayrollAsync(Payroll payroll, CancellationToken cancellationToken)
        {
           await _context.payrolls.AddAsync(payroll, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return payroll;
        }

        public async Task<Payroll> DeletePayrollAsync(int id, CancellationToken cancellationToken)
        {
           var data = await _context.payrolls.FindAsync(id);
            if (data != null)
            {
                _context.payrolls.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }

        public async Task<IEnumerable<Payroll>> GetAllPayrollsAsync(CancellationToken cancellationToken)
        {
            var data = await _context.payrolls.ToListAsync(cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Payroll> GetPayrollByIdAsync(int id, CancellationToken cancellationToken)
        {
           var dta = await _context.payrolls.FindAsync(id);
            if (dta != null)
            {
                return dta;
            }
            return null;
        }

        public async Task<Payroll> UpdatePayrollAsync(Payroll payroll, CancellationToken cancellationToken)
        {
           var data = await _context.payrolls.FindAsync(payroll.ID);
            if (data != null)
            {
                data.MonthYear = payroll.MonthYear;
                data.Basic = payroll.Basic;
                data.Allowance = payroll.Allowance;
                data.Deduction = payroll.Deduction;
                data.NetPay = payroll.NetPay;
                data.GeneratedDate = payroll.GeneratedDate;
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
