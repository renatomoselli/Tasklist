using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.IO.Compression;

namespace Tasklist.Web.Core.ActionFilters
{
    public class TasklistAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            // comentado pois não uso login
            //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    filterContext.Result = new RedirectResult("~/Account/Login");
            //    return;
            //}

            //if (filterContext.Result is HttpUnauthorizedResult)
            //{
            //    filterContext.Result = new RedirectResult("~/Account/AccessDenied");
            //}
        }
    }
}
