using LordsOfScotland.WebUI.Models;
using LordsOfScotland.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.WebSockets;
using System.Web.SessionState;
using LordsOfScotland.Data;
using LordsOfScotland.Core.Models;

namespace LordsOfScotland.WebUI.Services
{
    /// <summary>
    /// Description résumée de GestionnaireHttp
    /// </summary>
    public class GestionnaireHttp : IHttpHandler, IRequiresSessionState
    {
        private IJoueurService joueurService;
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(new GestionnaireWebSocket());
                if (context.Items["Id"]==null || Convert.ToUInt32(context.Items["Id"]) < 1)
                {
                    context.Items.Add("Id", Joueur.NbJoueurs+1);
                }
                context.Session["Id"] = context.Items["Id"];
                //try
                //{
                //    Joueur joueurCourant = joueurService.Trouve(Convert.ToUInt32(context.Items["Id"]));
                //    context.Session["joueur"] = joueurCourant;
                //}
                //catch (Exception ex)
                //{

                //    //throw;
                //}

            }
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public GestionnaireHttp()
        {
            joueurService = new JoueurService(new JoueurRepository());
        }
    }
}