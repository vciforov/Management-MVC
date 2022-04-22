using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }

        //Relationships

        public List<Project> Projects { get; set; }
    }
}
