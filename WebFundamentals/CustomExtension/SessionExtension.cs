using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFundamentals.CustomExtension
{
    public static class SessionExtension //Extension yazabilmemiz için metodun ve classın static olması gerekir
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            //Json a çeviriyoruz
            string data = JsonConvert.SerializeObject(value);
            session.SetString(key, data);//Sessiona atatık
        }

        public static T GetObject<T>(this ISession session, string key) where T:class,new()
        {
            //Session dan datamızı aldık
            var data=session.GetString(key);

            if (data!=null)
            {
                //Json dan objeye çevirme işlemi yaptık
                return JsonConvert.DeserializeObject<T>(data);
            }
            return null;
           
        }
    }
}
