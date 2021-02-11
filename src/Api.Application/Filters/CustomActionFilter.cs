using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Application.Filters
{

    public class CustomActionFilter : ActionFilterAttribute, IActionFilter
    {
        private string _permission;
        public CustomActionFilter(string permission) {
            _permission = permission;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.HasClaim("Permissions", _permission))
                base.OnActionExecuting(context);
        }
    }
}
