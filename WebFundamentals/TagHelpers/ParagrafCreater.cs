using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFundamentals.TagHelpers
{
    [HtmlTargetElement("eray")] //Hangi HTML etiketiyle çalıştığımı belirtmemiz gerekiyor.
    public class ParagrafCreater:TagHelper
    {
        public string GetData { get; set; } //View tarafından gelen datamız için propery oluşturduk

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var tagBuilder = new TagBuilder("p");//Bana dönecek olan HTML etiketini tanımladık
            tagBuilder.InnerHtml.AppendHtml("<b>Eray Tag Helper</b>"+" Viewden gelen data:"+GetData);
            output.Content.SetHtmlContent(tagBuilder);

            base.Process(context, output);
        }
    }
}
