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
        public IActionResult Index() //DİKKAT!!!!!!! Sanırım Problem burada yatıyor, problem de şu ındex metodunda partial ile ilgili işlem yapacağız.
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult YeniMesaj() // Bu kod ile aşağıdaki kod aynı aşağıdaki kod ile view oluşturduk ve Contact viewinde çağırdık  ve çok güzel çalışıyor, sayfa ile iletişime geçmek isteyen biri contact viewinde verilerini girerek iletişim kurrmasını sağladık. 
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<PartialViewResult> YeniMesaj(
    [Bind("User,Email,Subject,Messaje")] Contact p)
        {
            _databaseContext.Contacts.Add(p);
            await _databaseContext.SaveChangesAsync();
            return PartialView();
           
        }


       
    }
}
