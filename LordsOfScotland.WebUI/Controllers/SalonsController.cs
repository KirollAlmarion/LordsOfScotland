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
    public class SalonsController : Controller
    {

        private IJoueurService joueurService;
        private ISalonService salonService;

        public SalonsController()
        {
            joueurService = new JoueurService(new JoueurRepository());
            salonService = new SalonService(new SalonRepository());
        }
        // GET: Salons
        public ActionResult Index(int page = 1, byte maxParPage = Constantes.MAX_PAR_PAGE, string searchField = "")
        {
            var salons = salonService.ListeSalons(page, maxParPage, searchField);
            ViewBag.Page = page;
            ViewBag.maxParPage = maxParPage;
            ViewBag.searchField = searchField;
            ViewBag.NextExist = salonService.ExisteSuivant(page, maxParPage, searchField);
            return View(salons);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string nom)
        {
            if (nom != "")
            {
                Salon nouveau = new Salon((Joueur)Session["joueur"], nom);
                salonService.Ouvre(nouveau);
                Session["salon"] = nouveau;
                return RedirectToAction("Interieur");
            }
            else
            {
                return View(nom);
            }
        }

        public ActionResult Interieur()
        {
            Salon salonActuel = (Salon)Session["salon"];
            return View(salonActuel);
        }
    }
}