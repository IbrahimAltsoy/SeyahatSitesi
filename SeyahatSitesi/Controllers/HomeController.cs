using Microsoft.AspNetCore.Mvc;

using SeyahatSitesi.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeyahatSitesi.Models.Class;
using Microsoft.EntityFrameworkCore;

namespace SeyahatSitesi.Controllers


{

    public class HomeController : Controller
        
    {
       
        
        private readonly ILogger<HomeController> _logger;
        private readonly Context _databaseContext;


        public HomeController(ILogger<HomeController> logger, Context databaseContext = null)
        {

            _logger = logger;
            _databaseContext = databaseContext;
        }
        BlogYorum index = new BlogYorum();
        [HttpGet]
        public IActionResult Index()
        {
            // Video 21 de girdiği sınıfa buradan işlemleri yapacaksın tıpkı .sehir ve blog taki gibi index sayfasına istek ayarlşarını buradan yaparsın 
            index.Deger5 = _databaseContext.Blogs.Take(10).ToList();

            return View(index);
        }

        [HttpGet]
        public IActionResult About()
        {

            var deger = _databaseContext.Abouts.ToList();
            return View(deger);
        }
        public IActionResult Destinations()
        {
            return View();
        }
        BlogYorum by = new BlogYorum();
        [HttpGet]
        public IActionResult Blog(int id)
        {
            by.Deger1 = _databaseContext.Blogs.Where(x => x.Id == id).ToList();
            by.Deger2 = _databaseContext.Comments.Where(x => x.Blogid == id).ToList();
            
            //by.Deger1 = _databaseContext.Blogs.ToList();
            //by.Deger2 = _databaseContext.Comments.ToList();
            return View(by);

        }
        // bÜTÜN HATA BURADA EŞİTLENMEYE ÇALIŞILAN İD DE SAKLIDIR. İD LER BİRBİRİNE EŞİT OLMADIĞI İÇİN LİSTELEME YAPMIYOR YAPMADIĞI YERDEN DEĞERLERİ TAŞIMIYOR
        BlogYorum yor = new BlogYorum();
        [HttpGet]
        public IActionResult Sehir()
        {
            //var deger = _databaseContext.Abouts.ToList();
            //by.Deger1 = _databaseContext.Blogs.Where(x => x.Id == id).ToList();
            yor.Deger1 = _databaseContext.Blogs.ToList();
            yor.Deger2 = _databaseContext.Comments.ToList();
            yor.Deger3 = _databaseContext.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            //by.Deger1=_databaseContext.Blogs.ToList();
            //by.Deger2 = _databaseContext.Comments.ToList();

            return View(yor);

           
        }
        public IActionResult Contact()
        {
            return View();
        }
        BlogYorum partial = new BlogYorum();
        [HttpGet]
        public PartialViewResult Partial1()
        {
            //int maxsimum = _databaseContext.Blogs.Count();
            partial.Deger4 = _databaseContext.Blogs.OrderByDescending(x => x.Id).Take(2).ToList();
            //partial.Deger5 = _databaseContext.Blogs.ToList();
            return PartialView(partial);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
