using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Data;
using ProjectMVC.Models;
using ProjectMVC.Services;

namespace ProjectMVC.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientsService _service;

        public ClientsController(IClientsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //GET: Clients/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var clientsInfo = await _service.GetByIdAsync(id);
            if (clientsInfo == null) return View("NotFound");
            return View(clientsInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }

            await _service.UpdateAsync(client);
            return RedirectToAction(nameof(Index));
        }
        //GET: Employees/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var clientsInfo = await _service.GetByIdAsync(id);
            if (clientsInfo == null) return View("NotFound");
            return View(clientsInfo);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int clientId)

        {
            var clientsInfo = await _service.GetByIdAsync(clientId);
            if (clientsInfo == null) return View("NotFound");

            await _service.DeleteAsync(clientId);
            return RedirectToAction(nameof(Index));
        }
        
        //Get: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }

            await _service.AddAsync(client);
            return RedirectToAction(nameof(Index));
        }

    }
}
