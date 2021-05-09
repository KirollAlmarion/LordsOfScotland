using LordsOfScotland.Core.Models;
using LordsOfScotland.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LordsOfScotland.Data
{
    public class JoueurRepository: IJoueurRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Joueur> joueurs;

        public JoueurRepository()
        {
            joueurs = cache["joueurs"] as List<Joueur>;
            if (joueurs == null)
            {
                joueurs = new List<Joueur>();
            }
        }

        public void SaveChanges()
        {
            cache["joueurs"] = joueurs;
        }

        public void Actualise(Joueur j)
        {
            int index = joueurs.IndexOf(joueurs.Find(joueur => joueur.Id == j.Id));

            if (index > -1)
            {

                joueurs.RemoveAt(index);
                joueurs.Insert(index,j);
                SaveChanges();
            }
            else
            {
                throw new Exception(Constantes.MSG_ERREUR[(int)Constantes.Erreurs.joueurIntrouvable]);
            }
        }

        public void Supprime(uint id)
        {
            Joueur joueurSupp = joueurs.Find(j => j.Id == id);
            if (joueurSupp != null)
            {
                joueurs.Remove(joueurSupp);
                SaveChanges();
            }
            else
            {
                throw new Exception(Constantes.MSG_ERREUR[(int)Constantes.Erreurs.joueurIntrouvable]);
            }
        }

        public Joueur Trouve(uint id)
        {
            Joueur j = joueurs.Find(joueur => joueur.Id == id);
            if (j != null)
            {
                return j;
            }
            else
            {
                throw new Exception(Constantes.MSG_ERREUR[(int)Constantes.Erreurs.joueurIntrouvable]);
            }
        }

        public void Cree(Joueur j)
        {
            joueurs.Add(j);
            SaveChanges();
        }
    }
}
