using LordsOfScotland.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfScotland.WebUI.Services
{
    public interface IJoueurService
    {
        Joueur Trouve(uint id);
        void Cree(Joueur j);
        void Actualise(Joueur j);
        void Supprime(uint id);
    }
}
