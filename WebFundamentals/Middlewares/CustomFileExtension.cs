using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFundamentals.Middlewares
{
    public static class CustomFileExtension
    {
        public static void UseCustomStaticFile(this IApplicationBuilder app)
        {
            app.UseStaticFiles();
        }
    }
}
