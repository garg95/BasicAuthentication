using BasicAuthentication.DataLayer;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BasicAuthentication.CustomerFilters
{
    public class BasicAuthenticationAttribute :AuthorizationFilterAttribute //requires namespace 
    {
        public override void OnAuthorization(HttpActionContext actionContext) //this parameter provides access to both request and response
        {
            //password that is sent by client will be in base64 format and also in this form "username:password"
            if(actionContext.Request.Headers.Authorization==null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedauthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodedauthenticationToken.Split(':');
                string username = usernamePasswordArray[0];
                string password = usernamePasswordArray[1];
                if(EmployeeDetails.Login(username,password))
                {
                    //Now we want to set principals to the username who is executing this code
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

        }
    }
}