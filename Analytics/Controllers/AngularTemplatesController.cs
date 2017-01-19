using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Analytics.Controllers
{
    public class AngularTemplatesController : Controller
    {
        //// GET: AngularTemplates
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [ChildActionOnly]
        public ActionResult Inline()
        {
            IEnumerable<string> templateNames = Directory
                .GetFiles(Server.MapPath("~/dist/admin/"))
                .Select(Path.GetFileNameWithoutExtension);

            //return View(templateNames);
            return PartialView(templateNames);
        }

        public ActionResult Template(string name)
        {
            if (name == null || !Regex.IsMatch(name, @"^[-\w]+$"))
                throw new ArgumentException("Illegal template name", "name");

            //string relativeViewPath = string.Format("~/Views/AngularTemplates/Templates/{0}.cshtml", name);
            //string relativeViewPath = string.Format("~/dist/admin/{0}.cshtml", name);
            string relativeViewPath = string.Format("~/Views/Admin/{0}.cshtml", name);



            return View(relativeViewPath);
        }
    }
}