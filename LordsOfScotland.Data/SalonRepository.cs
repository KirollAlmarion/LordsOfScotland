using LordsOfScotland.Core.Models;
using LordsOfScotland.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfScotland.Data
{
    public class SalonRepository: ISalonRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Salon> salons;

        public SalonRepository()
        {
            salons = cache["salons"] as List<Salon>;
            if (salons == null)
            {
                salons = new List<Salon>();
            }
        }

        public void Actualise(Salon s)
        {
            Salon salonActu = salons.Find(salon => salon.Id == s.Id);
            if (salonActu != null)
            {
                salonActu = s;
                SaveChanges();
            }
            else
            {
                throw new Exception(Constantes.salonIntrouvable);
            }
        }

        public int Compte(string rechch)
        {
            IQueryable<Salon> req = (IQueryable<Salon>)salons;
            if (rechch != null && !rechch.Trim().Equals(""))
            {
                rechch = rechch.Trim().ToLower();
                req = req.Where(s => s.Nom.ToLower().Contains(rechch));
            }
            return req.Count();
        }

        public void Entre(Joueur j, uint id)
        {
            try
            {
                Salon salon = Trouve(id);
                if (salon.Joueurs.Count <5)
                {
                    salon.Joueurs.Add(j);
                    SaveChanges();
                }
                else
                {
                    throw new Exception(Constantes.salonPlein);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Salon> ListeSalons(int start, byte max, string rechch)
        {
            IQueryable<Salon> req = (IQueryable<Salon>)salons.OrderBy(s=>s.Nom);
            if (rechch != null && !rechch.Trim().Equals(""))
            {
                rechch = rechch.Trim().ToLower();
                req = req.Where(s => s.Nom.ToLower().Contains(rechch));
            }
            req = req.Skip(start).Take(max);
            return req.ToList();
        }

        public void Ouvre(Salon salon)
        {
            salons.Add(salon);
            SaveChanges();
        }

        public void SaveChanges()
        {
            cache["salons"] = salons;
        }

        public void Sort(Joueur j, uint id)
        {
            try
            {
                Salon salon = Trouve(id);
                salon.Joueurs.Remove(j);
                SaveChanges();
                if (salon.Joueurs.Count == 0)
                {
                    Ferme(id);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Ferme(uint id)
        {
            Salon salonSupp = salons.Find(s => s.Id == id);
            if (salonSupp != null)
            {
                salons.Remove(salonSupp);
                SaveChanges();
            }
            else
            {
                throw new Exception(Constantes.salonIntrouvable);
            }
        }

        public Salon Trouve(uint id)
        {
            Salon s = salons.Find(salon => salon.Id == id);
            if (s != null)
            {
                return s;
            }
            else
            {
                throw new Exception(Constantes.salonIntrouvable);
            }
        }
    }
}
