using LordsOfScotland.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LordsOfScotland.WebUI.Controllers
{
    public class ErreursController : Controller
    {
        // GET: Erreurs
        public ActionResult Index(byte errnum)
        {
            ViewBag.Erreur = Constantes.MSG_ERREUR[errnum];
            return View();
        }
    }
}