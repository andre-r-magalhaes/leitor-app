using br.com.anddo.lector.api.Models;
using br.com.anddo.lector.etl;
using Newtonsoft.Json.Converters;
using System.Web.Mvc;

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
            if (p != null)
                return Newtonsoft.Json.JsonConvert.SerializeObject(p, new StringEnumConverter());
            else
                return Newtonsoft.Json.JsonConvert.SerializeObject(new ApiMessage(false, "Produto não encontrado."));
        }
    }
}
