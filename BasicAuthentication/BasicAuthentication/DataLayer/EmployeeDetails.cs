using BasicAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthentication.DataLayer
{
    public class EmployeeDetails
    {
        public static bool Login(string name,string password)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
                return employeeContext.employees.Any(x => 
                    x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && x.Password == password);
        }
        public List<Employee> GetEmployees(string gender)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
                return employeeContext.employees.Where(x =>
                    x.Gender==gender).ToList();
        }
    }
}