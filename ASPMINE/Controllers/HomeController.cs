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
            var etud = dbd.etudiants.SingleOrDefault(x => x.Nom.Equals(username) && x.password.Equals(password));
            String passwordp = Request.Form["passp"];
            String emailp = Request.Form["emailp"];
            var prof = dbd.professeurs.SingleOrDefault(x => x.Nom.Equals(emailp) && x.password.Equals(passwordp));
       
            if (etud != null)
            {
                etudiant e = (etudiant)etud;
                return View("etudiant", e);
            }
           else if (prof != null)
            {
                professeur e = (professeur)prof;
                return View("professeur", e);
            }

            return View();
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
        public ActionResult inscriptionp()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult inscriptione()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}