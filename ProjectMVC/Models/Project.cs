using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace ProjectMVC.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }

        //Relationships

        public List<EmployeeProject> EmployeeProjects { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
