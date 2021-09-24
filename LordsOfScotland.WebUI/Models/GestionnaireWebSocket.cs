using LordsOfScotland.Core.Models;
using LordsOfScotland.Data;
using LordsOfScotland.WebUI.Services;
using Microsoft.Web.WebSockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace LordsOfScotland.WebUI.Models
{
    public class GestionnaireWebSocket: WebSocketHandler
    {
        private IJoueurService joueurService;
        private ISalonService salonService;
        private static WebSocketCollection toutesLesConnexions = new WebSocketCollection();

        public GestionnaireWebSocket()
        {
            joueurService = new JoueurService(new JoueurRepository());
            salonService = new SalonService(new SalonRepository());
        }

        public override void OnOpen()
        {
            toutesLesConnexions.Add(this);
            //string nom = this.WebSocketContext.LogonUserIdentity.Name;
            //Joueur joueurCourant = joueurService.Trouve(Convert.ToUInt32(this.WebSocketContext.Items["Id"]));
            //joueurCourant.Nom = nom;
            //joueurService.Actualise(joueurCourant);
            //base.Send(JsonConvert.SerializeObject("Utilisateur " + nom + " n°" + this.WebSocketContext.Items["Id"] + " connecté!"));

            while (true)
            {
                //base.Send(JsonConvert.SerializeObject("Time now is: " + DateTime.Now));
                //System.Threading.Thread.Sleep(1000);
            }
        }

        public override void OnClose()
        {
            uint id = Convert.ToUInt32(this.WebSocketContext.Items["Id"]);
            joueurService.Supprime(id);
            base.OnClose();
        }
    }
}