using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebFundamentals.Areas.Admin.Controllers
{
    [Area("Admin")] //Endpoint karmaşası olmaması için Area ismi tanımladık
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}