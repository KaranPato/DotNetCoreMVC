using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Hello World");
        }
    }
}