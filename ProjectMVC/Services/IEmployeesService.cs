using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectMVC.Models;

namespace ProjectMVC.Services
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> UpdateAsync(Employee newEmployee);
        Task DeleteAsync(int id);
        Task AddAsync(Employee employee);   
    }
}
