using ASPMINE.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace ASPMINE.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String s)
        {
            String password = Request.Form["passet"];
            String username = Request.Form["emailet"];
            projet1aspEntities  dbd = new projet1aspEntities();
            var p = dbd.etudiants.SingleOrDefault(x => x.Nom.Equals(username) && x.password.Equals(password));
         //   var prof=dbd.etudiants.SingleOrDefault
            if (p != null)
            {
                etudiant e = (etudiant)p;
                return View("etudiant", e);
            }
            else
            {
                return View();
            }

        }
        public ActionResult etudiant()
        {
            return View();
        }
        [HttpPost]
        public ActionResult etudiant(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
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
        public ActionResult professeur()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}