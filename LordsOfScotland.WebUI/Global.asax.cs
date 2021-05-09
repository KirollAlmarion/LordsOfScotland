using LordsOfScotland.Core.Models;
using LordsOfScotland.Data;
using LordsOfScotland.WebUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LordsOfScotland.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private IJoueurService joueurService;
        public MvcApplication()
        {
            joueurService = new JoueurService(new JoueurRepository());
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Joueur joueurCourant = (Joueur)Session["joueur"];
            joueurService.Supprime(joueurCourant.Id);
        }
    }
}
