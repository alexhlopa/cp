using System.Linq;
using CrossPlatformLab5.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;

namespace CrossPlatformLab5.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OktaDefaults.MvcAuthenticationScheme);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult OktaSignOut()
        {
            return new SignOutResult(new[]
            {
                OktaDefaults.MvcAuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme
            },
            new AuthenticationProperties() { RedirectUri = "/Home/" });
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var phone = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "phone_number");
            return View(new UserProfileModel()
            {
                Email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email")?.Value.ToString() ?? "not specified",
                FirstName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "given_name")?.Value.ToString() ?? "not specified",
                LastName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "family_name")?.Value.ToString() ?? "not specified",
                UserName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "preferred_username" || x.Type == "name")?.Value.ToString() ?? "not specified",
                PhoneNumber = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "phone_number")?.Value.ToString() ?? "not specified"
            });
        }
    }
}
