using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mywebsite.Filters
{
    public class AuthorizeAdmin: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            bool isLoggedAsAdmin = !string.IsNullOrEmpty(session.GetString("isAdmin"));
            if (!isLoggedAsAdmin)
                filterContext.Result = new BadRequestObjectResult("Access denied!");
        }
    }
}


