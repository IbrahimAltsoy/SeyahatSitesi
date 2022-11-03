using Microsoft.AspNetCore.Mvc;
using SeyahatSitesi.Models.Class;

namespace SeyahatSitesi.Controllers
{
    public class YorumController : Controller
    {
        private readonly ILogger<YorumController> _logger;
        private readonly Context _databaseContext;
        public YorumController(ILogger<YorumController> logger, Context databaseContext = null)
        {

            _logger = logger;
            _databaseContext = databaseContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var deger = _databaseContext.Blogs.ToList();
            return View(deger);
        }
         // Blog sayfası altında YORUM YAPMAYA ÇALIŞTIK BECEREMEDİK SAYFANIN TEK EKSİK YÖNÜ BU KALDI
    //    [HttpGet]
    //    public PartialViewResult YorumYap()
    //    {
    //        return PartialView();
    //    }
    //    [HttpPost]
    //    public async Task<PartialViewResult> YorumYap(
    //[Bind("User,Email,Commentss,Blogid")] BlogYorum p)
    //    {
    //        _databaseContext.Comments.Add((Comment)p.Deger2);
    //        await _databaseContext.SaveChangesAsync();
    //        return PartialView();

    //    }

    }
}
