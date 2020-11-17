using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebFundamentals.Models;

namespace WebFundamentals.Controllers
{
    [Route("kisiler/[action]")] //Startup Route tarafını ezer.
    public class HomeController : Controller
    {
      [Route("Anasayfa")]
        public IActionResult Index()
        {
            ViewBag.Isim = "Eray";//ViewData ile ViewBag aynıdır,aynı adresi tutarlar ve bulundukları action'a özeldir
            TempData["Isim"] = "Eray";//Actionlar arası bilgi taşımak için kullanılır
            ViewData["Isim"] = "Eray";

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
    }
}