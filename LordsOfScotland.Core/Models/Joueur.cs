using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfScotland.Core.Models
{
    public class Joueur: BaseEntity
    {
        public string Nom { get; set; }
        //public byte Numero { get; set; }
        public bool Initiative { get; set; }
        public List<byte> Jeu { get; set; }
        public List<Allie> Armee { get; set; }
    }
}
