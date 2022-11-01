using Microsoft.AspNetCore.Mvc;
using SeyahatSitesi.Models.Class;
using System.Security.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace SeyahatSitesi.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly Context _databaseContext;
        public LoginController(ILogger<LoginController> logger, Context databaseContext = null)
        {

            _logger = logger;
            _databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            if (claimuser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
                // satır 60 admin yerine login yazmayı dene bakalım ne oluyor 
            }
            return View();
        }
        //[HttpPost]
        //public IActionResult Login(Admin admin)
        //{
        //    var control = _databaseContext.Admins.FirstOrDefault(x => x.User == admin.User && x.Password == admin.Password);
        //    if(control != null)
        //    {
        //       Forms....

        //    }
        //}
        [HttpPost]
        public async Task<IActionResult> Login(Admin admin)
        {
            var control = _databaseContext.Admins.FirstOrDefault(x => x.User == admin.User && x.Password == admin.Password);
            if (control != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,admin.User),
                    new Claim("OtherProperties", "Example Role")
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties proporties = new AuthenticationProperties() 
                {
                    AllowRefresh = true,
                    IsPersistent = admin.Equals("admin")
                    // Equals e dikkat et çalıştırmayabilir 
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity), proporties);
                return RedirectToAction("Index", "Admin");

            }
            //else
            //{ // 3.50 murat yücedağ 
            //    return RedirectToAction("Login", "Login");
            // bu kodun yerine aşağıdakini dene bakalım ne olcak
            //}
            ViewData["ValidateMessage"] = "Kullanıcı bulunamadı tekrar deneyiniz";
            return View();
            
        }

    }
}
