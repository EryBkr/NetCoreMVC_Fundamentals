using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebFundamentals.CustomFilters;
using WebFundamentals.Models;

namespace WebFundamentals.Controllers
{
  
    public class HomeController : Controller
    {
     
        public IActionResult Index()
        {
            ViewBag.Isim = "Eray";//ViewData ile ViewBag aynıdır,aynı adresi tutarlar ve bulundukları action'a özeldir
            TempData["Isim"] = "Eray";//Actionlar arası bilgi taşımak için kullanılır
            ViewData["Isim"] = "Eray";

            //Cookie ataması ve erişimini çağırdık
            SetCookie();
            ViewBag.Cookie = GetCookie();

            return View(new List<MusteriViewModel>() //View'e liste gönderiyorum
            {
                new MusteriViewModel{Id=1,Name="Eray"},
                new MusteriViewModel{Id=2,Name="Berkay"}
            });
        }

        public IActionResult Sonuc()
        {
            return View();
        }

        public IActionResult KayitOl()
        {
            return View();
        }

        [ValidationControl]//Yazdığımız Attribute yi burada kullanıyoruz
        [HttpPost]
        public IActionResult KayitOl(UserRegisterModel userRegisterModel)
        {
            if (ModelState.IsValid) //Validasyon kontrollerimizi yapıyoruz
            {

            }
            ModelState.AddModelError(nameof(UserRegisterModel.Ad), "Ad Alanı Gereklidir"); //Ekstra özellik eklersek bu şekilde de belirtebiliriz.
            ModelState.AddModelError("","Model ile ilgili hatalar");
            return View(userRegisterModel);
        }

        public void SetCookie()
        {
            HttpContext.Response.Cookies.Append("kisi", "eray", new Microsoft.AspNetCore.Http.CookieOptions()
            {
                Expires = DateTime.Now.AddDays(20), //20 gün hayatta kalsın
                HttpOnly = true,//XSS karşı koruma sağlar
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,//Web sayfaları erişimi
                Secure = true //Https ile çalışır
            });
        }

        public string GetCookie()
        {
            return HttpContext.Request.Cookies["kisi"]; //Cookie değerimizi aldık
        }
    }
}