using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFundamentals.Models;

namespace WebFundamentals.CustomFilters
{
    public class ValidationControl:ActionFilterAttribute //Filtre işlemleri için kalıtım aldık
    {
        public override void OnActionExecuting(ActionExecutingContext context)//Model bağlandıktan sonra,action çalışmadan önce gelir
        {
            var dict=context.ActionArguments.Where(i => i.Key == "userRegisterModel").FirstOrDefault(); //Action a gelen parametre ismini veriyorum
            var model = (UserRegisterModel)dict.Value;
            if (model.Ad.ToLower()=="eray")
            {
                context.Result = new RedirectResult(@"\Home\Error"); //isim kontrolü sonucunda istediğimiz sayfaya yönlendirebiliyoruz
            }
        }
    }
}
