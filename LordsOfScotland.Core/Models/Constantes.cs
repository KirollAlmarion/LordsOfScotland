using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfScotland.Core.Models
{
    public static class Constantes
    {
        public const byte MAX_PAR_PAGE = 5;

        //messages d'erreur:
        public enum Erreurs: byte
        {
            joueurIntrouvable, salonIntrouvable, salonPlein
        }

        public static string[] MSG_ERREUR =
        {
            "Joueur non trouvé.",
            "Salon non trouvé.",
            "Salon plein."
        };
        //public const string joueurIntrouvable = "Joueur non trouvé.",
        //                    salonIntrouvable = "Salon non trouvé.",
        //                    salonPlein = "Salon plein.";

        public enum NomClan: byte
        {
            Inactif, Scott, MakGill, MacDonnell, Wemyss, Fergusson, Forsyth, Cockburn, Cochrane, Bruce
        };

        public static Clan[] CLANS = {
                        new Clan{
                            Nom= NomClan.Inactif,
                            Pouvoir= "Inactif",
                            Couleur= "white",
                        },
                        new Clan{
                            Nom= NomClan.Scott,
                            Pouvoir= "Copiez le pouvoir d'un autre allié",
                            Couleur= "forestgreen",
                        },
                        new Clan{
                            Nom= NomClan.MakGill,
                            Pouvoir= "Engagez un autre allié",
                            Couleur= "goldenrod",
                        },
                        new Clan{
                            Nom= NomClan.MacDonnell,
                            Pouvoir= "Reste une manche de plus",
                            Couleur= "darkgreen",
                        },
                        new Clan{
                            Nom= NomClan.Wemyss,
                            Pouvoir= "Défaussez un autre allié",
                            Couleur= "maroon",
                        },
                        new Clan{
                            Nom= NomClan.Fergusson,
                            Pouvoir= "Echangez-le contre un autre allié",
                            Couleur= "chocolate",
                        },
                        new Clan{
                            Nom= NomClan.Forsyth,
                            Pouvoir= "Piochez une carte",
                            Couleur= "saddlebrown",
                        },
                        new Clan{
                            Nom= NomClan.Cockburn,
                            Pouvoir= "Echangez-le contre un partisan",
                            Couleur= "midnightblue",
                        },
                        new Clan{
                            Nom= NomClan.Cochrane,
                            Pouvoir= "Récupérez deux partisans",
                            Couleur= "indigo",
                        },
                        new Clan{
                            Nom= NomClan.Bruce,
                            Pouvoir= "N'importe quel clan",
                            Couleur= "black",
                        }
        };

        public static Carte[] PAQUET = new Carte[99];        

        static Constantes()
        {
            for (byte numClan = 1; numClan < 9; numClan++)
            {
                for (byte i = 1; i < 13; i++)
                {
                    PAQUET[numClan + 8 * (i - 1)] = new Carte { Clan = CLANS[numClan], Force = i };
                }
            }
            for (byte i = 97; i < 99; i++)
            {
                PAQUET[i] = new Carte { Clan = CLANS[9], Force = 12 };
            }
        }
    }
}
