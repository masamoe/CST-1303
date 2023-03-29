using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers
{
    public class DocumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
