using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Data;
using ProjectMVC.Models;
using ProjectMVC.ViewModels;

namespace ProjectMVC.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly AppDbContext _context;

        public ProjectsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var projectDetails = await _context.Projects
                .Include(c => c.Client)
                .Include(ep => ep.EmployeeProjects).ThenInclude(e => e.Employee)
                .FirstOrDefaultAsync(n => n.ProjectId == id);
            return projectDetails;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            var result = await _context.Projects.ToListAsync();
            return result;
        }

        public async Task<NewProjectDropDownVm> GetNewProjectDropDown()
        {
            var result = new NewProjectDropDownVm()
            {
                Clients = await _context.Clients.ToListAsync(),
                Employees = await _context.Employees.ToListAsync()
            };

            return result;
        }

        public async Task AddNewProjectAsync(NewProjectVm values)
        {
            var newProject = new Project()
            {
                ProjectName = values.ProjectName,
                ClientId = values.ClientId,
                StartDate = values.StarDate,
                EndDate = values.EndDate,

            };
            await _context.Projects.AddAsync(newProject);
            await _context.SaveChangesAsync();

            //Employees
            foreach (var employeesId in values.EmployeeIds)
            {
                var newEmployeeProject = new EmployeeProject()
                {
                    ProjectId = newProject.ProjectId,
                    EmployeeId = employeesId
                };
                await _context.EmployeeProjects.AddAsync(newEmployeeProject);

            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(NewProjectVm values)
        {
            var dbProject = await _context.Projects.SingleOrDefaultAsync(n => n.ProjectId == values.ProjectId);

            if (dbProject != null)
            {

                dbProject.ProjectName = values.ProjectName;
                dbProject.ClientId = values.ClientId;
                dbProject.StartDate = values.StarDate;
                dbProject.EndDate = values.EndDate;

                await _context.SaveChangesAsync();

            }
            var dbEmployees = _context.EmployeeProjects.Where(n => n.ProjectId == values.ProjectId).ToList();

            _context.EmployeeProjects.RemoveRange(dbEmployees);

            await _context.SaveChangesAsync();

            foreach (var employeesId in values.EmployeeIds)
            {
                var newEmployeeProject = new EmployeeProject()
                {
                    ProjectId = values.ProjectId,
                    EmployeeId = employeesId
                };
                await _context.EmployeeProjects.AddAsync(newEmployeeProject);

            }

            await _context.SaveChangesAsync();


        }
    }
}
