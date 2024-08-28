using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NagarPalika.Application.Commands.Authentication;
using NagarPalika.Web.Models;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NagarPalika.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Login()
        {
            return View(new AuthenticationRequest());
        }
        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationRequest authenticationRequest)
        {
            authenticationRequest.IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var res = await _mediator.Send(authenticationRequest);
            if (res.Succeeded)
            {
                var handler = new JwtSecurityTokenHandler();
                var tokenParse = handler.ReadToken(res.Data.AccessToken) as JwtSecurityToken;
                var tokenExpiryDate = tokenParse.Payload["Expire"];


                HttpContext.Session.SetString("UserId", res.Data.UserId.ToString());
                HttpContext.Session.SetString("RoleId", res.Data.RoleId.ToString());
                HttpContext.Session.SetString("AccessToken", res.Data.AccessToken);
                HttpContext.Session.SetString("TokenExpire", Convert.ToString(tokenExpiryDate));
                HttpContext.Session.SetString("UserName", res.Data.UserName);
                HttpContext.Session.SetString("UserFullName", res.Data.UserFullName);
                HttpContext.Session.SetString("Designation", res.Data.Designations);
                HttpContext.Session.SetString("Picture", res.Data.Picture);

                var userClaims = new List<Claim>()
                {
                  new Claim(ClaimTypes.Email, res.Data.AccessToken),
                 };

                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                await HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("DashBoard");
            }
            return View(authenticationRequest);
        }

        [CustomAuthorization]
        public async Task<IActionResult> DashBoard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            foreach (var cookie in HttpContext.Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key);
            }
            return RedirectToAction("Login", "Home");
        }

    }
}