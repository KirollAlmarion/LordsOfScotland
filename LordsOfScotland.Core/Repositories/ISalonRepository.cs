using LordsOfScotland.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfScotland.Core.Repositories
{
    public interface ISalonRepository
    {
        List<Salon> ListeSalons(int start, int max, string rechch);
        int Compte(string rechch);
        void Ouvre(Salon s);
        Salon Trouve(uint id);
        void Actualise(Salon s);
        void Ferme(uint id);
        void Entre(Joueur j, uint id);
        void Sort(Joueur j, uint id);
    }
}
