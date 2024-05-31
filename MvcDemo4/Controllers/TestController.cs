using Microsoft.AspNetCore.Mvc;

namespace MvcDemo4.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
