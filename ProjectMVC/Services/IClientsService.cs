using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectMVC.Models;

namespace ProjectMVC.Services
{
    public interface IClientsService
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task<Client> UpdateAsync(Client newClient);
        Task DeleteAsync(int id);
        Task AddAsync(Client client);
    }           
}
