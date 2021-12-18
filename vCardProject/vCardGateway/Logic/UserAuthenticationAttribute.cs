using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using vCardGateway.Models;

namespace vCardGateway.Logic
{
    public class UserAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers
                    .Authorization.Parameter;

                // decoding authToken we get decode value in 'Username:Password' format  
                var decodeauthToken = System.Text.Encoding.UTF8.GetString(
                    Convert.FromBase64String(authToken));

                // spliting decodeauthToken using ':'   
                var arrUserNameandPassword = decodeauthToken.Split(':');

                // at 0th postion of array we get username and at 1st we get password  
                User user = IsAuthorizedUser(arrUserNameandPassword[0], arrUserNameandPassword[1]);
                if (user != null)
                {
                    if (user.active)
                    {
                        GenericPrincipal principal = new GenericPrincipal(
                                                       new GenericIdentity(user.id.ToString(), user.type.ToString()), null);
                        Thread.CurrentPrincipal = principal;
                        if (HttpContext.Current != null)
                        {
                            HttpContext.Current.User = principal;
                        }
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request
                       .CreateResponse(HttpStatusCode.Unauthorized, "This user is deactivated");
                    }
                        
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        public static User IsAuthorizedUser(string Username, string Password)
        {
            // In this method we can handle our database logic here...  
            SQLUsersHandler handler = new SQLUsersHandler();
            return handler.authenticate(Username, Password);
        }
    }
}