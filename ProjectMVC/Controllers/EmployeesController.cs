using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Data;
using ProjectMVC.Models;
using ProjectMVC.Services;

namespace ProjectMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _service;

        public EmployeesController(IEmployeesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //GET: Employees/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var employeesInfo = await _service.GetByIdAsync(id);
            if (employeesInfo == null) return View("NotFound");
            return View(employeesInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            await _service.UpdateAsync(employee);
            return RedirectToAction(nameof(Index));
        }

        //GET: Employees/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var employeesInfo = await _service.GetByIdAsync(id);
            if (employeesInfo == null) return View("NotFound");
            return View(employeesInfo);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int employeeId)

        {
            var employeesInfo = await _service.GetByIdAsync(employeeId);
            if (employeesInfo == null) return View("NotFound");

            await _service.DeleteAsync(employeeId);
            return RedirectToAction(nameof(Index));
        }

        //Get: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            await _service.AddAsync(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
