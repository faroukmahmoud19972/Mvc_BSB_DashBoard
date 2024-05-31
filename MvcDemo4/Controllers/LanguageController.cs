using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using MvcDemo4.BL.Models;

namespace MvcDemo4.Controllers
{
    public class LanguageController : Controller
    {
        [HttpGet]
        public IActionResult SetLanguage(LanguageViewModel model)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(model.culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(model.returnurl);
        }

    }
}
