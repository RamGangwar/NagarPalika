using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NagarPalika.Application.Repository;
using System.Net;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomAuthorizationAttribute : TypeFilterAttribute
{

    public CustomAuthorizationAttribute() : base(typeof(UnauthorizedFilter))
    {
        //Empty constructor
    }
}
public class UnauthorizedFilter : IAuthorizationFilter
{
    private readonly IEmployeeRepository _user = null;
    public UnauthorizedFilter(IEmployeeRepository user)
    {
        _user = user;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userid = context.HttpContext.Session.GetString("UserId");
        var userstatus = _user.GetById(Convert.ToInt32(userid)).Result;
        if ((userstatus != null && userstatus.IsActive == false))
        {
            context.Result = new RedirectResult("~/Home/Login");
        }

        if (string.IsNullOrEmpty(context.HttpContext.Session.GetString("UserId")) || DateTime.Now > Convert.ToDateTime(context.HttpContext.Session.GetString("TokenExpire")))
        {

            // not logged in
            if (context.HttpContext.Request.IsAjaxRequest())
            {
                context.HttpContext.Response.StatusCode =
                (int)HttpStatusCode.Unauthorized; //Set HTTP unauthorized
            }
            else
            {
                context.Result = new RedirectResult("~/Home/Login");
            }
        }
    }
}

public static class AjaxExtension
{
    //HttpRequest Extension method to 
    //check if the incoming request is an AJAX call
    public static bool IsAjaxRequest(this HttpRequest request)
    {
        if (request == null)
            throw new ArgumentNullException("request");

        if (request.Headers != null)
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        return false;
    }
}

