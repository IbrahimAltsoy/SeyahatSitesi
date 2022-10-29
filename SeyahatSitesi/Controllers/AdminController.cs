using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeyahatSitesi.Models.Class;

namespace SeyahatSitesi.Controllers
{
    public class AdminController : Controller

    {
        private readonly ILogger<AdminController> _logger;
        private readonly Context _databaseContext;
        public AdminController(ILogger<AdminController> logger, Context databaseContext = null)
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
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult YeniBlog(Blog p)
        //{
        //    _databaseContext.Blogs.Add(p);
        //    _databaseContext.SaveChangesAsync();
        //    return RedirectToAction("Index");

        //}   
        //    Şuraya yani indexe yönlendirmiş oluruz parametreden gelen değer kaydedilten ve yapılan değişikliği kaydettikten sonra indexe yönlendir demiş oluyoruz.



       
        // üstteki kodta ekleme yapıyor fakat aşağıdaki daha güzel yapıyor, sayfayı çağırdığı gibi yenilediği için hemen client ediyor
        [HttpPost]
        public async Task<IActionResult> YeniBlog(
    [Bind("Baslik,DateTime,BlogImage,Text")] Blog p)
        {
            _databaseContext.Blogs.Add(p);
            await _databaseContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}
