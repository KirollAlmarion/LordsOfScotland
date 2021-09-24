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
        public ActionResult Index(int page = 1, byte maxParPage = Constantes.MAX_PAR_PAGE, string searchField = "", string erreur="")
        {
            var salons = salonService.ListeSalons(page, maxParPage, searchField);
            Joueur joueurCourant = (Joueur)Session["joueur"];
            ViewBag.Page = page;
            ViewBag.maxParPage = maxParPage;
            ViewBag.searchField = searchField;
            ViewBag.NomSalon = "Salon de " + joueurCourant.Nom;
            if (erreur != "") ViewBag.Erreur = erreur;
            ViewBag.NextExist = salonService.ExisteSuivant(page, maxParPage, searchField);
            return View(salons);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string nomSalon)
        {
            if (nomSalon != "")
            {
                Salon nouveau = new Salon((Joueur)Session["joueur"], nomSalon);
                salonService.Ouvre(nouveau);
                Session["salon"] = nouveau;
                return RedirectToAction("Interieur");
            }
            else
            {
                return View(nomSalon);
            }
        }

        public ActionResult EntreDansSalon(uint id)
        {
            try
            {
                salonService.Entre((Joueur)Session["joueur"], id);
                Session["salon"] = salonService.Trouve(id);
                return RedirectToAction("Interieur");
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals(Constantes.MSG_ERREUR[(int)Constantes.Erreurs.salonPlein]))
                {
                    return RedirectToAction("Index", new { erreur = Constantes.MSG_ERREUR[(int)Constantes.Erreurs.salonPlein] });
                }
                else
                {
                    return RedirectToAction("Index", "Erreurs", new { errnum = (byte)Constantes.Erreurs.salonIntrouvable });
                }
            }
        }

        public ActionResult Interieur()
        {
            Salon salonActuel = (Salon)Session["salon"];
            return View(salonActuel);
        }

        public ActionResult SortDuSalon()
        {
            Salon salonCourant = (Salon)Session["salon"];
            Joueur joueurCourant = (Joueur)Session["joueur"];
            salonService.Sort(joueurCourant, salonCourant.Id);
            Session["salon"] = null;
            return RedirectToAction("Index");
        }
    }
}