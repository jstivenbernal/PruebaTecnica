using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebPruebaTecnica.Service;
using WebPruebaTecnica.Models;
using Newtonsoft.Json;

namespace WebPruebaTecnica.Controllers
{
    public class HomeController : Controller
    {
        #region Configuracion Controlador

        static HttpClient client = new HttpClient();
        ConsumoApi api = new ConsumoApi();
        string urlApi = System.Configuration.ConfigurationManager.AppSettings["UrlApi"];

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Productos()
        {
            return View();
        }

        public ActionResult Facturas()
        {
            return View();
        }

        #region JsonResult

        [HttpGet]
        public JsonResult GetProductos()
        {
            List<ProductoViewModels> list = new List<ProductoViewModels>();
            var path = urlApi + "Productos/GetProductos";
            string response = api.GetApiHttpGet(path);
            list = JsonConvert.DeserializeObject<List<ProductoViewModels>>(response);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFacturas()
        {
            List<FacturaViewModels> list = new List<FacturaViewModels>();
            var path = urlApi + "Facturas/GetFacturas";
            string response = api.GetApiHttpGet(path);
            list = JsonConvert.DeserializeObject<List<FacturaViewModels>>(response);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}