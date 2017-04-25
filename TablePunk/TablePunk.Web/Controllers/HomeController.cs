using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TablePunk.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            /*
            if (Request.Files.Count == 1)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    string pathToSave = Server.MapPath("~/Content/Files/");
                    string filename = Path.GetFileName(Request.Files[0].FileName);
                    Request.Files[0].SaveAs(Path.Combine(pathToSave, filename));
                }

            }
            */
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
