using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            ViewBag.Title = "Shell";
            string o = ShellHelper.RunShell();
<<<<<<< HEAD
=======
            Thread.Sleep(TimeSpan.FromSeconds(5));
>>>>>>> 5ee0f3bc722e3c7b1733292632d921754ff19ffc
            return View((object)o);
        }

    }
}
