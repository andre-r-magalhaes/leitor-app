using br.com.anddo.lector.domain;
using br.com.anddo.lector.etl;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace br.com.anddo.lector.api.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        public string Get(string code)
        {
            var etl = new SAPETL();
            var p = etl.GetProduct(code);
            return new JavaScriptSerializer().Serialize(p);
        }
    }
}
