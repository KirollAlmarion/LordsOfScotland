using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfScotland.Core.Models
{
    public class Salon: BaseEntity
    {
        public string Nom { get; set; }
        public List<Joueur> Joueurs { get; set; }
        public List<byte> Pioche { get; set; }
        public List<byte> Defausse { get; set; }
        public List<byte> Partisans { get; set; }
        public List<byte> Recrues { get; set; }
        private uint max;

        public Salon(Joueur j, string nom)
        {
            max++;
            Id = max;
            Joueurs = new List<Joueur>();
            Joueurs.Add(j);
            j.Initiative = true;
            if (nom.Equals("") || nom == null)
            {
                Nom = "Salon de " + j.Nom;
            }
            else
            {
                Nom = nom;
            }
        }
    }
}
