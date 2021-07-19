using LordsOfScotland.Core.Models;
using LordsOfScotland.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordsOfScotland.WebUI.Services
{
    public class JoueurService: IJoueurService
    {
        private JoueurRepository joueurRepository;

        public JoueurService(JoueurRepository joueurRepository)
        {
            this.joueurRepository = joueurRepository;
        }

        public void Actualise(Joueur j)
        {
            joueurRepository.Actualise(j);
        }

        public void Cree(Joueur j)
        {
            joueurRepository.Cree(j);
        }

        public void Supprime(uint id)
        {
            joueurRepository.Supprime(id);
        }

        public Joueur Trouve(uint id)
        {
            try
            {
                return joueurRepository.Trouve(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}