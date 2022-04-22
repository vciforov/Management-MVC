using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProjectMVC.Data;
using ProjectMVC.Models;
using ProjectMVC.Services;
using ProjectMVC.ViewModels;

namespace ProjectMVC.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectsService _service;

        public ProjectsController(IProjectsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProjects = await _service.GetAllAsync();
            return View(allProjects);
        }


        public async Task<IActionResult> Create()
        {

            var dropDowns = await _service.GetNewProjectDropDown();
            ViewBag.Clients = new SelectList(dropDowns.Clients, "ClientId", "CompanyName");
            ViewBag.Employees = new SelectList(dropDowns.Employees, "EmployeeId", "EmployeeFullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProjectVm project)
        {
            if (!ModelState.IsValid)
            {
                var dropDowns = await _service.GetNewProjectDropDown();
                ViewBag.Clients = new SelectList(dropDowns.Clients, "ClientId", "CompanyName");
                ViewBag.Employees = new SelectList(dropDowns.Employees, "EmployeeId", "EmployeeFullName");
                return View(project);
            }

            await _service.AddNewProjectAsync(project);
            return RedirectToAction(nameof(Index));
        }

        //GET: Project/Details
        public async Task<IActionResult> Details(int id)
        {
            var projectDetails = await _service.GetProjectByIdAsync(id);
            return View(projectDetails);
        }

        //GET: Project/Edit
        public async Task<IActionResult> Edit(int id)
        {

            var projectDetails = await _service.GetProjectByIdAsync(id);
            if (projectDetails == null) return View("NotFound");

            var returnDetails = new NewProjectVm()
            {
                ProjectId = projectDetails.ProjectId,
                ProjectName = projectDetails.ProjectName,
                ClientId = projectDetails.ClientId,
                StarDate = projectDetails.StartDate,
                EndDate = projectDetails.EndDate,
                EmployeeIds = projectDetails.EmployeeProjects.Select(e => e.EmployeeId).ToList(),
            };
            var dropDowns = await _service.GetNewProjectDropDown();
            ViewBag.Clients = new SelectList(dropDowns.Clients, "ClientId", "CompanyName");
            ViewBag.Employees = new SelectList(dropDowns.Employees, "EmployeeId", "EmployeeFullName");

            return View(returnDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewProjectVm project)
        {
            if (!ModelState.IsValid)
            {
                var dropDowns = await _service.GetNewProjectDropDown();
                ViewBag.Clients = new SelectList(dropDowns.Clients, "ClientId", "CompanyName");
                return View(project);
            }

            await _service.UpdateProjectAsync(project);
            return RedirectToAction(nameof(Index));
        }
    }
}