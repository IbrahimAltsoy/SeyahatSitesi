using Microsoft.AspNetCore.Mvc;
using SeyahatSitesi.Models.Class;


namespace SeyahatSitesi.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly Context _databaseContext;


        public ContactController(ILogger<ContactController> logger, Context databaseContext = null)
        {

            _logger = logger;
            _databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult YeniMesaj()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<PartialViewResult> YeniMesaj(
    [Bind("User,Email,Subject,Messaje")] Contact p)
        {
            _databaseContext.Contacts.Add(p);
            await _databaseContext.SaveChangesAsync();
            return PartialViewResult(nameof(Index));
        }

        private PartialViewResult PartialViewResult(string v)
        {
            throw new NotImplementedException();
        }
    }
}
