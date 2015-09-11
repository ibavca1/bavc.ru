using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bavc.ru.Helpers;

namespace bavc.ru.Controllers
{
    public class ShellController : Controller
    {
        //
        // GET: /Shell/

        public ActionResult Index()
        {
            ViewBag.Titile = "Shell";
            string o = ShellHelper.RunShell();
            return View((object)o);
        }

    }
}
