using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OktaBlazorAspNetCoreServerSide.Areas.Identity.Data
{
    public class AccountController : Controller
    {
        [Route("Identity/Account/Login")]
        public IActionResult Login()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
            }
            return Redirect("~/");
        }

        [Route("Identity/Account/LogOut")]
        public IActionResult LogOut()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return new SignOutResult(new[]
                {
                    OpenIdConnectDefaults.AuthenticationScheme,
                    CookieAuthenticationDefaults.AuthenticationScheme
                });
            }
            return Redirect("~/");
        }
    }
}