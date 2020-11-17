using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFundamentals.ViewComponents
{
    public class Urunler:ViewComponent
    {
        public IViewComponentResult Invoke() //Asenkron bir yapı olduğu için Invoke metodunun çağırılması gerekiyor---> Components/Component-Name/Default.cshtml
        {
            var list = new ArrayList();
            list.Add("1.eleman");
            list.Add("2.eleman");

            return View(list); //Componente Data gönderdik
        }
    }
}
