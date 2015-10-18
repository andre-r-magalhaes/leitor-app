using br.com.anddo.lector.etl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace br.com.anddo.lector.api.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //Mock m = new Mock();
            //m.execute();

            return View();
        }

    }
}
