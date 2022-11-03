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
        public IActionResult Index()// Indexe BlogYorum değer5 nesne oluşturduk ve bu nesnenin blogtan ilk 8 elemanı alıp listelemesini talep ettik , View e gittiğimizde ise foreach ile slider e image dosyasını çektiğimizi gözlemledik.
        {
            
            index.Deger5 = _databaseContext.Blogs.Take(8).ToList();

            return View(index);
        }

        [HttpGet]
        public IActionResult About()// burada ise database abouts tablosundan nesne türettik ve about sayfası üzerinden çağırdık about iew ine gittiğimzde ise tablodan sadece about çektik EKLENECEK OLAN İSE VERTABANINDA PRROJE TANITIMI VE BİR İMAJE DOSYASI İLE BERABER YÜKLEMEK OLACAK

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
        public IActionResult Blog(int id) // Sanırım projenin en can alıcı noktalarından biri de burası çünkü Blog view nine partial viewler eklendi ve ilişkiler tablolardan veri toplamaya çalıştığımız bir alan ve aşağıdaki kod blokuna baktığımızda hem blogs tablosu hem de comments tablosunu Blog yani burada listeledik. Blog viewinde ise kurduğumuz algoritma ile eğer comments tablosunun blogid si Blogs tablosunun id sine eşit ise oradaki yorumun listelenmesini talep ettik ve bunu çalıştırdık.
        {
            by.Deger1 = _databaseContext.Blogs.Where(x => x.Id == id).ToList();
            by.Deger2 = _databaseContext.Comments.Where(x => x.Blogid == id).ToList();
            
            //by.Deger1 = _databaseContext.Blogs.ToList();
            //by.Deger2 = _databaseContext.Comments.ToList();
            return View(by);

        }              
        
        BlogYorum yor = new BlogYorum();
        [HttpGet]
        public IActionResult Sehir() // Projenin önemli kısımlarından bir yer, BlogYorumdan oluşturduğumuz iki ayrı nesne oluşturduk aşağıdaki kodla görülüyor. biri Blogs tablosu biri commnets tablosu diğeri ise Blogs tablosunun id sine göre tersten ilk 3 değeri almasını için nesnelerimiz hazır, Sehir view ine gittiğimzde ise  Değer1 ve Değer3 ten oluşturduğumuz nesnelerin talebinde bulunduk ve çalışıyor:) 
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
        public IActionResult Contact()// burada oluşturduğumuz iletişim sayfasını boş bıraktık fazlalıktır aslında projeden silinebilir, projenin başında oluşturulmuştu. İlerleyen süreçte ContactConrellerde detaylandırarak yaptık, bunun için oraya gidilebilir. 
        {
            return View();
        }
        BlogYorum partial = new BlogYorum();
        [HttpGet]
        public PartialViewResult Partial1() // Anasayda index için burada partil view oluşturduk , ındex sayfasına gittiğimizde bu partialviewleri çağırdık, clasın içinde ise BlogYorum Değer4 ten oluşturduğumuz nesneleri tersten sıralayarak ilk  değeri döndürmesini talep ettik
        {
            //int maxsimum = _databaseContext.Blogs.Count(); 
            partial.Deger4 = _databaseContext.Blogs.OrderByDescending(x => x.Id).Take(2).ToList();
            //partial.Deger5 = _databaseContext.Blogs.ToList();
            return PartialView(partial);
        }
        BlogYorum partial2 = new BlogYorum();
        [HttpGet]
        public PartialViewResult Partial2() // burası da üsteki partial viewlwe aynı görevi görüyor, algoritmik hata var aslında eğer sağlam bir algoritma oluşturmuş olsaydık iki farklı partial oluşturmamıza gerek kalmadan tek partial üzerinden istediğimizi yaptırabilirdik.
        {
            partial2.Deger4=_databaseContext.Blogs.OrderBy(x => x.Id).Take(3).ToList();
            return PartialView(partial2);
        }

        // AŞAĞISI KARIŞIK :) yorumyaptırmayı partial üzerinden yapmaya çalıştık beceremedik hatta bunu becerebilmek için YorumController ekledik yine olmadı, Hatanın bütün çabada elde edilen veriye göre  _databaseContext.Comments.Add((Comment)p.Deger2); buradaki kodun yanlışlığı ,  EKSİK KALAN YER İSE BLOG VİEWİNE YENİ YORUM YAPTIRMAK, BU KISMINI BECEREMEDİK ORASI EKSİK KALDI VE PROJENİN EN ÖNEMLİ EKSİĞİ OLARAK DEĞERLENDİREBİLİRİZ. BU KONUDA UZMAN BİRİNDEN YARDIM TALEBİ GEREKTİRECEK KADAR EMEK VERİLDİ. 
        // buraya yorum yapı eklemeye çalıştım olmadı çalışmadı malesef
        //    [HttpGet]
        //    public PartialViewResult YorumYap()
        //    {
        //        return PartialView();
        //    }
        //    
        //    [HttpPost]
        //    public async Task<PartialViewResult> YorumYap(
        //[Bind("User,Email,Commentss,Blogid")] BlogYorum p)
        //    {
        //        object a = p.Deger2;

        //        _databaseContext.Comments.Add();
        //        //_databaseContext.Comments.Add((Comment)p.Deger2);
        //        await _databaseContext.SaveChangesAsync();
        //        return PartialView();

        //    }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() // projede sql bağlarken hazır gelen kod olarak biliniyor yine de araştırabilirsin 
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
