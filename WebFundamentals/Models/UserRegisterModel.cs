using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebFundamentals.Models
{
    public class UserRegisterModel
    {
        [Required] //Data Annotations yardımıyla modellerimize validasyon ekleyebiliriz Requried Zorunlu alan özelliği kazandırır
        public string Ad { get; set; }
        [Required(ErrorMessage ="Soyadı gereklidir")]
        public string Soyad { get; set; }
    }
}
