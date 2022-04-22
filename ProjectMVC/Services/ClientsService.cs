using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Data;
using ProjectMVC.Models;

namespace ProjectMVC.Services
{
    public class ClientsService : IClientsService
    {
        private readonly AppDbContext _context;

        public ClientsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == id);
            _context.Clients.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            var result = await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == id);
            return result;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var result = await _context.Clients.ToListAsync();
            return result;
        }

        public async Task<Client> UpdateAsync(Client newEcClient)
        {
            _context.Update(newEcClient);
            await _context.SaveChangesAsync();
            return newEcClient;
        }
        public async Task AddAsync(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();

        }
    }
}
