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
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "Nom")] Joueur nouveau)
        {
            if (ModelState.IsValid)
            {
                joueurService.Cree(nouveau);
                Session["joueur"] = nouveau;
                return RedirectToAction("AfficheSalons");
            }
            else
            {
                return View(nouveau);
            }
        }

        public ActionResult AfficheSalons(int page = 1, byte maxParPage = Constantes.MAX_PAR_PAGE, string searchField = "")
        {
            var salons = salonService.ListeSalons(page, maxParPage, searchField);
            ViewBag.Page = page;
            ViewBag.maxByPage = maxParPage;
            ViewBag.searchField = searchField;
            ViewBag.NextExist = salonService.ExisteSuivant(page, maxParPage, searchField);
            return View("Index", salons);
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