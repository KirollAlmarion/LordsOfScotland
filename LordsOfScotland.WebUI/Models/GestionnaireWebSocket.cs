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

        public GestionnaireWebSocket()
        {
            joueurService = new JoueurService(new JoueurRepository());
            salonService = new SalonService(new SalonRepository());
        }

        public override void OnOpen()
        {
            string nom = this.WebSocketContext.LogonUserIdentity.Name;
            Joueur nouveau = new Joueur(nom);
            joueurService.Cree(nouveau);
            this.WebSocketContext.Items.Add("Id", nouveau.Id.ToString());
            //Session["joueur"] = nouveau;
            var certif = this.WebSocketContext.ClientCertificate;
            certif.Add("Id", nouveau.Id.ToString());
            

            base.Send(JsonConvert.SerializeObject("Utilisateur " + nom + " n°" + certif.Get(0) + " connecté!"));

            while (true)
            {
                //base.Send(JsonConvert.SerializeObject("Time now is: " + DateTime.Now));
                //System.Threading.Thread.Sleep(1000);
            }
        }

        public override void OnClose()
        {
            var certif = this.WebSocketContext.ClientCertificate;
            uint id = Convert.ToUInt32(certif.Get(0));
            joueurService.Supprime(id);
            base.OnClose();
        }
    }
}