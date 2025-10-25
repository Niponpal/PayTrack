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

        // Add Employee
        public async Task<Employee> AddEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _context.Employees.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return employee;
        }

        // Delete Employee
        public async Task<Employee?> DeleteEmployeeAsync(int id, CancellationToken cancellationToken)
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

   

        // Get All Employees + Include Designation
        public async Task<IEnumerable<Employee>> GetAllEmployeeAsynce(CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Include(e => e.Designation)
                .ToListAsync(cancellationToken);
        }

        // Get Employee By ID + Include Designation
        public async Task<Employee?> GetEmployeeByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Include(e => e.Designation)
                .FirstOrDefaultAsync(e => e.ID == id, cancellationToken);
        }

        // Update Employee
        public async Task<Employee?> UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
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
                data.DesignationID = employee.DesignationID; // Update FK
                _context.Employees.Update(data);
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
