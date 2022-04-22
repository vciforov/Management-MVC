using ProjectMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Data;

namespace ProjectMVC.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly AppDbContext _context;

        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            _context.Employees.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var result = await _context.Employees.ToListAsync();
            return result;
        }

        public async Task<Employee> UpdateAsync(Employee newEmployee)
        {
            _context.Update(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee;
        }
            
        public async Task AddAsync(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();

        }
    }
}
