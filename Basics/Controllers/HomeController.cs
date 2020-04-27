using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Basics
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var parlaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Mike"),
                new Claim(ClaimTypes.Email, "mike@gmail.com"),
                new Claim("Parla.Says", "Very nice boi"),
            };

            var licenseClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"John K Foo"),
                new Claim(ClaimTypes.Email, "john@gmail.com"),
                new Claim("DrivingLicence", "A+"),
            };

            var parlaIdentity = new ClaimsIdentity(parlaClaims, "Parla Identity");
            var licenseIdentity = new ClaimsIdentity(licenseClaims, "License Driving");

            var userPrincipal = new ClaimsPrincipal(new[] { parlaIdentity,licenseIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}
