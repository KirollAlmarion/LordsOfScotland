using LordsOfScotland.Core.Models;
using LordsOfScotland.Data;
using LordsOfScotland.WebUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LordsOfScotland.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IJoueurService joueurService;
        private ISalonService salonService;

        public HomeController()
        {
            joueurService = new JoueurService(new JoueurRepository());
            salonService = new SalonService(new SalonRepository());
        }

        public ActionResult Index()
        {
            if (Session["joueur"] != null) return RedirectToAction("Index", "Salons");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string nom)
        {
            if (nom != "")
            {
                Joueur nouveau = new Joueur(nom);
                joueurService.Cree(nouveau);
                Session["joueur"] = nouveau;
                return RedirectToAction("Index", "Salons");
            }
            else
            {
                return View(nom);
            }
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
    }
}