using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DCAS_PracticalExam.Controllers
{
    public class ConsentCookiesController : Controller
    {
        [HttpGet]
        public IActionResult SetCookie()
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, // Set HttpOnly attribute to true
                IsEssential = true,
                Secure = true, // if you want to restrict the cookie to HTTPS
                SameSite = SameSiteMode.None, // or SameSiteMode.Strict, SameSiteMode.Lax
                Expires = DateTimeOffset.UtcNow.AddYears(1) // set expiry time
            };
            Response.Cookies.Append("ConsentCookies", "Yes", cookieOptions);

            return Ok("Cookie set successfully!");
        }

    }
}
