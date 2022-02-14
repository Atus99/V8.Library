using Microsoft.AspNetCore.Mvc;

namespace V8.HangFire.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/hangfire");
        }
    }
}
