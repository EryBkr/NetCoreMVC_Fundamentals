using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebFundamentals.CustomLogger;

namespace WebFundamentals.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PageError(int code)
        {
            ViewBag.Code = code;
            if (code == 404)
            {
                ViewBag.ErrorMessage = "Sayfa Bulunamadı";
            }
            return View();
        }

        public IActionResult Error() //Global Hata Actionu
        {
            var exceptionHandlerPathFeature =
          HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            //LOG işlemleri
            var logger = new NLogLogger();
            logger.
                LogWithNLog($"hatanın oluştuğu yer" +
                $" {exceptionHandlerPathFeature.Path}" +
                $" \n " +
                $"hata mesajı:{exceptionHandlerPathFeature.Error.Message} \n " +
                $"stack trace:{exceptionHandlerPathFeature.Error.StackTrace}");

            ViewBag.Path = exceptionHandlerPathFeature.Path;
            ViewBag.Message = exceptionHandlerPathFeature.Error.Message;

            return View();
        }

        public IActionResult ErrorThrow() //Hata oluşturduğumuz action
        {
            throw new Exception("Hata Oluştu");
            return View();
        }
    }
}