using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFramework.Interfaces;

namespace WebFramework.Web
{
    public class WebPage<TModel>:IWebPage
    {
        public int GroupId { get; set; }
        
        public WebContent Content { get; set; }
        
        public Uri Uri { get; set; }
        
        public Func<TModel> FuncParse { get; set; }

        public TModel Model
        {
            get { return Content.GetParsePage<TModel>(FuncParse); }
        }

        public WebPage()
        {
            PageType = typeof (TModel);
            Content = new WebContent();
            FuncParse = null;
        }

        public WebPage(string url)
            : this()
        {
            Uri = new Uri(url);
        }

        public WebPage(string url, string html)
            :this()
        {
            Uri = new Uri(url);
            Content.InnerHtml = html;
        }

        public Type PageType { get; private set; }
    }
}
