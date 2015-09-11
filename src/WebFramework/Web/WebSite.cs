using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using WebFramework.Interfaces;

namespace WebFramework.Web
{
    class WebSite
    {
        public CookieCollection Cookies { get; set; }
        public IList<IWebPage> Pages { get; set; }
    }
}
