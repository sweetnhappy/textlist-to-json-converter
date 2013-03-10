using System;
using System.Linq;
using System.Web.Mvc;

namespace TextList_To_Json_Converter.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /

        public ActionResult Index()
        {
            return RedirectToAction("Index", "TextListToJson");
        }
    }
}
