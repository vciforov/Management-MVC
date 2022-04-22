using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using ProjectMVC.Models;

namespace ProjectMVC.ViewModels
{
    public class NewProjectVm
    {
        public int ProjectId { get; set; }

        [Display(Name = "Project Name")]    
        [Required(ErrorMessage = "Project name is required!")]
        public string ProjectName { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is required!")]
        public DateTime StarDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is required!")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Employees")]
        [Required(ErrorMessage = "Please choose a at least one employee")]
        public List<int> EmployeeIds { get; set; }

        [Display(Name = "Clients")]
        [Required(ErrorMessage = "Please choose a client")]
        public int ClientId { get; set; }


    }
}
