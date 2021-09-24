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
        private ISalonService salonService;

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.Items.Add("Id", context.Session["Id"].ToString());
                context.AcceptWebSocketRequest(new GestionnaireWebSocket());

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
            salonService = new SalonService(new SalonRepository());
        }
    }
}