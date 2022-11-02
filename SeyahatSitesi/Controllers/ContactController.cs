using Microsoft.AspNetCore.Mvc;

namespace SeyahatSitesi.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
