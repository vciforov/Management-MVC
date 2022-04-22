using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectMVC.Data;
using ProjectMVC.Data.Enums;

namespace ProjectMVC.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string EmployeeFullName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeMobilePhone { get; set; }

        
        public DepartmentNumber DepartmentNumber { get; set; }  

        //Relationships

        public List<EmployeeProject> EmployeeProjects { get; set; } 

    }       
}
