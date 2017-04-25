using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TablePunk.Web.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _environment;

        public HomeController(IHostingEnvironment env)
        {
            this._environment = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFiles(IList<IFormFile> files)
        {
            long size = 0;
            foreach (var file in files)
            {
                var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                filename = _environment.WebRootPath + $@"\{filename}";
                size += file.Length;

                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }

            return this.RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
