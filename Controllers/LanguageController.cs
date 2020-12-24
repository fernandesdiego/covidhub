using System;
using Microsoft.AspNetCore.Mvc;

namespace HNEWS.Controllers
{
    public class LanguageController : Controller
    {
        [HttpGet]
        public IActionResult Portugues()
        {
            HttpContext.Response.Cookies.Append("language", "pt", new Microsoft.AspNetCore.Http.CookieOptions(){ Expires = DateTime.Now.AddYears(10) });
            return RedirectToAction("Index", "Home");
        }
        public IActionResult English()
        {
            HttpContext.Response.Cookies.Append("language", "en", new Microsoft.AspNetCore.Http.CookieOptions() { Expires = DateTime.Now.AddYears(10) });
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Espanol()
        {
            HttpContext.Response.Cookies.Append("language", "es", new Microsoft.AspNetCore.Http.CookieOptions() { Expires = DateTime.Now.AddYears(10) });
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Francais()
        {
            HttpContext.Response.Cookies.Append("language", "fr", new Microsoft.AspNetCore.Http.CookieOptions() { Expires = DateTime.Now.AddYears(10) });
            return RedirectToAction("Index", "Home");
        }

    }
}
