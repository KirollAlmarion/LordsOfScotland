using LordsOfScotland.Core.Models;
using LordsOfScotland.Data;
using LordsOfScotland.WebUI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace LordsOfScotland.WebUI.Tests.Services
{
    [TestClass]
    public class ServicesTest
    {
        static JoueurRepository joueurRepository = new JoueurRepository();
        static JoueurService joueurService = new JoueurService(joueurRepository);
        static Joueur j1;
        

        [ClassInitialize]//s'exécute une fois avant toutes les méthodes de test
        public static void Setup(TestContext TestContext)
        {
            j1 = new Joueur("MacLeod");
            joueurService = new JoueurService(new JoueurRepository());
            joueurService.Cree(j1);
            MessageBox.Show("Class Initialize");
        }
        [TestMethod]
        [TestCategory("Services")]
        public void CreerJoueur()
        {
            uint tailleAvantInsertion = Joueur.NbJoueurs;
            Joueur j2 = new Joueur("MacLeod");
            joueurService.Cree(j2);
            uint tailleApresInsertion = Joueur.NbJoueurs;
            Assert.AreEqual(tailleAvantInsertion+1, tailleApresInsertion);
        }

        [TestMethod]
        [TestCategory("Services")]
        public void TrouverJoueur()
        {
            string nom = "MacLeod";
            Joueur resultat = joueurService.Trouve(1);

            Assert.AreEqual(nom, resultat.Nom);
        }

        [TestMethod]
        [TestCategory("Services")]
        public void ModifierJoueur()
        {
            string nom = "Connery";
            Joueur modif1 = joueurService.Trouve(2);
            modif1.Nom = nom;
            //joueurService.Actualise(modif);
            Joueur modif2 = joueurService.Trouve(2);
            Assert.AreEqual(nom, modif2.Nom);
        }
    }
}
