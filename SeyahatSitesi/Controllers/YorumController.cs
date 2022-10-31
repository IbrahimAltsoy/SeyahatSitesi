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
        //[HttpGet]
        //public PartialViewResult YorumYap()
        //{
        //    return PartialView();
        //}
        //[HttpPost]
        //public PartialViewResult YorumYap(BlogYorum c)
        //{
        //    _databaseContext.Comments.Add((Comment)c.Deger6);
        //    _databaseContext.SaveChangesAsync();
        //    return PartialView();
        //}
    //    [HttpPost]
    //    public async Task<PartialViewResult> YorumYap(
    //[Bind("User,Email,Commentss,BlogId")] BlogYorum p)
    //    {
    //       _databaseContext.Comments.Add(_databaseContext.Comments.FirstOrDefault());
    //        await _databaseContext.SaveChangesAsync();
    //        return PartialView(p);
    //    }
    }
}
