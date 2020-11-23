﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
            if (code==404)
            {
                ViewBag.ErrorMessage = "Sayfa Bulunamadı";
            }
            return View();
        }
    }
}