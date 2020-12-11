using BasicAuthentication.CustomerFilters;
using BasicAuthentication.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace BasicAuthentication.Controllers
{
    [BasicAuthentication]
    public class ValuesController : ApiController
    {
        EmployeeDetails employeeDetails = new EmployeeDetails();
        // GET api/values
        public HttpResponseMessage Get(string gender="All")
        {
            string username = Thread.CurrentPrincipal.Identity.Name;//here we are passing gender as username from fiddler
            switch (username)
            {
                case "male":
                    return Request.CreateResponse(HttpStatusCode.OK,employeeDetails.GetEmployees(username));
                case "female":
                    return Request.CreateResponse(HttpStatusCode.OK, employeeDetails.GetEmployees(username));
                default:
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
