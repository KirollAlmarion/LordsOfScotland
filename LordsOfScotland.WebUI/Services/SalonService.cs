using LordsOfScotland.Core.Models;
using LordsOfScotland.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordsOfScotland.WebUI.Services
{
    public class SalonService: ISalonService
    {
        private SalonRepository salonRepository;

        public SalonService(SalonRepository salonRepository)
        {
            this.salonRepository = salonRepository;
        }

        public void Actualise(Salon s)
        {
            salonRepository.Actualise(s);
        }

        public void Entre(Joueur j, uint id)
        {
            salonRepository.Entre(j, id);
        }

        public bool ExisteSuivant(int page, byte maxParPage, string rechch)
        {
            return (page * maxParPage) < salonRepository.Compte(rechch);
        }

        public void Ferme(uint id)
        {
            salonRepository.Ferme(id);
        }

        public List<Salon> ListeSalons(int page, byte maxParPage, string rechch)
        {
            int start = (page - 1) * maxParPage;
            return salonRepository.ListeSalons(start, maxParPage, rechch);
        }

        public void Ouvre(Salon s)
        {
            salonRepository.Ouvre(s);
        }

        public void Sort(Joueur j, uint id)
        {
            salonRepository.Sort(j, id);
        }

        public Salon Trouve(uint id)
        {
            return salonRepository.Trouve(id);
        }
    }
}