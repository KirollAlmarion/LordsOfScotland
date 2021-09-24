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

        private static uint max;

        public Salon(Joueur j, string nom)
        {
            max++;
            Id = max;
            Joueurs = new List<Joueur>();
            Joueurs.Add(j);
            Pioche = new List<byte>();
            Defausse = new List<byte>();
            Partisans = new List<byte>();
            Recrues = new List<byte>();
            j.Initiative = true;
            if (string.IsNullOrEmpty(nom))
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
