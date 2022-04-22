using System.Collections.Generic;
using ProjectMVC.Models;

namespace ProjectMVC.ViewModels
{
    public class NewProjectDropDownVm
    {
        public NewProjectDropDownVm()
        {
            Clients = new List<Client>();
            Employees = new List<Employee>();
        }
        public List<Client> Clients { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
