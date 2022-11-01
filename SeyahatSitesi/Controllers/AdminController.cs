using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeyahatSitesi.Models.Class;

namespace SeyahatSitesi.Controllers
{
    // Autorize ekledik sayfaya admi naneline girmeye çalıştığımız vakit admine gitmiyor, direk login sayfasına atıyor. 
    [Authorize]
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

        public IActionResult Blogsil(int id)
        {
            var sil = _databaseContext.Blogs.Find(id);
            _databaseContext.Blogs.Remove(sil);
            _databaseContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult BlogGetir(int id)
        {
            var getir = _databaseContext.Blogs.Find(id);
            _databaseContext.Blogs.ToList();
            return View("BlogGetir", getir);
        }
        public IActionResult BlogGuncelle(Blog u)
        {
            var blg = _databaseContext.Blogs.Find(u.Id);
            blg.Text = u.Text;
            blg.Baslik=u.Baslik;
            blg.DateTime=u.DateTime;
            blg.BlogImage=u.BlogImage;
            _databaseContext.SaveChanges();
            return RedirectToAction("Index");
        }
        // Yorumları Listeleyeceğiz
        public IActionResult YorumListesi()
        {
            var yorum = _databaseContext.Comments.ToList();

            return View(yorum);
        }
        // Yorum silme işlemi
        public IActionResult YorumSil(int id)
        {
            var sil = _databaseContext.Comments.Find(id);
            _databaseContext.Comments.Remove(sil);
            _databaseContext.SaveChanges();

            return RedirectToAction("YorumListesi");
        }
        //Yorum Güncelleme işlemi
        public IActionResult YorumGetir(int id)
        {
            var getir = _databaseContext.Comments.Find(id);
            _databaseContext.Comments.ToList();
            return View("YorumGetir", getir);
        }
        public IActionResult YorumGuncelle(Comment u)
        {
            var blg = _databaseContext.Comments.Find(u.Id);
            blg.Id = u.Id;
            blg.User = u.User;
            blg.Email = u.Email;
            blg.Commentss = u.Commentss;
            blg.Blogid = u.Blogid;

            _databaseContext.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}
