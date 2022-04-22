using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectMVC.Models;
using ProjectMVC.ViewModels;

namespace ProjectMVC.Services
{
    public interface IProjectsService
    {
        Task<Project> GetProjectByIdAsync(int id);
        Task<IEnumerable<Project>> GetAllAsync();
        Task<NewProjectDropDownVm> GetNewProjectDropDown();
        Task AddNewProjectAsync(NewProjectVm values);
        Task UpdateProjectAsync(NewProjectVm values);  
    }
}
    