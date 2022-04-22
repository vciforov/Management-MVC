using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProjectMVC.Data.Enums;
using ProjectMVC.Models;

namespace ProjectMVC.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(new List<Employee>()
                        {
                            new Employee()
                            {
                                EmployeeFullName = "Stefan Stojanovski",
                                EmployeeMobilePhone = "071-333-111",
                                EmployeeEmail = "sstojanovski@yahoo.com",
                                DepartmentNumber = DepartmentNumber.Developer
                            },
                            new Employee()
                            {
                                EmployeeFullName = "Nikola Petrevski",
                                EmployeeMobilePhone = "071-333-222",
                                EmployeeEmail = "nikola@yahoo.com",
                                DepartmentNumber = DepartmentNumber.Developer
                            },
                            new Employee()
                            {
                                EmployeeFullName = "Petar Stefanovski",
                                EmployeeMobilePhone = "071-333-444",
                                EmployeeEmail = "petar@outlook.com",
                                DepartmentNumber = DepartmentNumber.QualityAssurance
                            },
                            new Employee()
                            {
                                EmployeeFullName = "Angela Ristovska",
                                EmployeeMobilePhone = "071-111-111",
                                EmployeeEmail = "angela@gmail.com",
                                DepartmentNumber = DepartmentNumber.Developer
                            },
                            new Employee()
                            {
                                EmployeeFullName = "Elena Stojanovska",
                                EmployeeMobilePhone = "071-333-111",
                                EmployeeEmail = "estojanovska@yahoo.com",
                                DepartmentNumber = DepartmentNumber.Management  
                            },


                        }
                    );
                    context.SaveChanges();

                }

                if (!context.Clients.Any())
                {
                    context.Clients.AddRange(new List<Client>()
                    {
                        new Client()
                        {
                            CompanyName = "Digital Bits",
                            CompanyEmail = "digit@gmail.com"
                           
                        },
                        new Client()
                        {
                            CompanyName = "QA Enterprise",
                            CompanyEmail = "enter@gmail.com"

                        },
                        new Client()
                        {

                            CompanyName = "Internship IO",
                            CompanyEmail = "inter@gmail.com"
                           

                        },


                    });
                    context.SaveChanges();

                }

            }
        }
    }
}
