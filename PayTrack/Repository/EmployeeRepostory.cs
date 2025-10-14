using Microsoft.EntityFrameworkCore;
using PayTrack.Data;
using PayTrack.Models;

namespace PayTrack.Repository
{
    public class EmployeeRepostory : IEmployeeRepostory
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepostory(ApplicationDbContext context)
        {
            _context = context;
        }
        async Task<Employee> IEmployeeRepostory.AddEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _context.Employees.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return employee;
        }

        async Task<Employee> IEmployeeRepostory.DeleteEmployeeAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Employees.FindAsync(id);
            if (data != null)
            {
                _context.Employees.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }

        async Task<IEnumerable<Employee>> IEmployeeRepostory.GetAllEmployeeAsynce(CancellationToken cancellationToken)
        {
            var data = await _context.Employees.ToListAsync(cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        async Task<Employee> IEmployeeRepostory.GetEmployeeByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Employees.FindAsync(id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        async Task<Employee> IEmployeeRepostory.UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
           var data = await _context.Employees.FindAsync(employee.ID);
            if (data != null)
            {
                data.FirstName = employee.FirstName;
                data.LastName = employee.LastName;
                data.Email = employee.Email;
                data.Phone = employee.Phone;
                data.JoiningDate = employee.JoiningDate;
                data.SalaryBase = employee.SalaryBase;
                data.Status = employee.Status;
                _context.Employees.Update(data);
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
