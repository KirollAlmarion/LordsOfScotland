using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LordsOfScotland.Core.Models.Constantes;

namespace LordsOfScotland.Core.Models
{
    public class Clan
    {
        public NomClan Nom { get; set; }
        public string Pouvoir { get; set; }
        public string Couleur { get; set; }
    }
}
