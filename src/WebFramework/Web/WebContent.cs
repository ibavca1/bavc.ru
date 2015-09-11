using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFramework.Web
{
    public class WebContent
    {
        public string InnerHtml { get; set; }

        public T GetParsePage<T>(Func<T> pFunc)
        {
            var parse = pFunc();
            return parse;
        }

        public T GetParseBlock<T>(string htmlBlock, Func<string, T> pFunc)
        {
            var parse = pFunc(htmlBlock);
            return parse;
        }

    }
}
