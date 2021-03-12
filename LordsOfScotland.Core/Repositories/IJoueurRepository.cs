using LordsOfScotland.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfScotland.Core.Repositories
{
    public interface IJoueurRepository
    {
        Joueur Trouve(uint id);
        void Cree(Joueur j);
        void Actualise(Joueur j);
        void Supprime(uint id);
    }
}
