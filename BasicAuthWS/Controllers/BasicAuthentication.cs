using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace BasicAuthWS.Controllers
{
    public class BasicAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(
                context.HttpContext.Request.Headers.Authorization))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            try
            {
                var authHeader =
                    context.HttpContext.Request.Headers.Authorization.ToString();

                var authHeaderParts = authHeader.Split(' ');

                if (authHeaderParts.Length != 2 ||
                    authHeaderParts[0] != "Basic")
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                var credentials =
                    Encoding.UTF8.GetString(
                        Convert.FromBase64String(
                            authHeaderParts[1]));

                var parts = credentials.Split(':');

                if (parts.Length != 2 ||
                    parts[0].ToLower() != "instructor01" ||
                    parts[1] != "Password01")
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                base.OnActionExecuting(context);
            }
            catch
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}