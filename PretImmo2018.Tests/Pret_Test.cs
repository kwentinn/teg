using NUnit.Framework;
using PretImmo2018.Models;
using System;
using System.Linq;

namespace Tests
{
    public class PretTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Pret_1_Test()
        {
            var montantBien = 263000;
            var apport = 91186;
            var fraisNotaries = 18410;
            var montantAEmprunter = montantBien - apport + fraisNotaries;
            var dureeEnAnnees = 15;
            var tauxNominal = 1.50 / 100;
            var pretSeul = new Pret("Crédit Test (teg de 1,50%)", montantAEmprunter, dureeEnAnnees, tauxNominal, new DateTime(2018, 12, 1)); 
            var echeances = pretSeul.GetEcheances();
            Assert.AreEqual(montantAEmprunter, pretSeul.MontantAEmprunter);
            Assert.AreEqual(tauxNominal, pretSeul.TauxNominal);
            Assert.AreEqual(dureeEnAnnees, pretSeul.DureeEnAnnees);
            Assert.AreEqual(180, pretSeul.GetDureeEnMois());
            Assert.AreEqual(new DateTime(2033,12,1), pretSeul.GetFinPret());
            Assert.AreEqual(1180.8, pretSeul.GetMensualitée(), 1);
            Assert.AreEqual(22320, pretSeul.GetCoutTotal(),1);
            Assert.AreEqual(8.52, pretSeul.GetTAEG(), 0.01);
        }

        [Test]
        public void Pret_2_Test()
        {
            var montantBien = 263000;
            var apport = 91186;
            var fraisNotaries = 18410;
            var montantAEmprunter = montantBien - apport + fraisNotaries;
            var dureeEnAnnees = 15;
            var tauxNominal = 1.65 / 100;
            var pretSeul = new Pret("Crédit Test (teg de 1,65%)", montantAEmprunter, dureeEnAnnees, tauxNominal, new DateTime(2018, 12, 1));
            var echeances = pretSeul.GetEcheances();
            Assert.AreEqual(montantAEmprunter, pretSeul.MontantAEmprunter);
            Assert.AreEqual(tauxNominal, pretSeul.TauxNominal);
            Assert.AreEqual(dureeEnAnnees, pretSeul.DureeEnAnnees);
            Assert.AreEqual(180, pretSeul.GetDureeEnMois());
            Assert.AreEqual(new DateTime(2033, 12, 1), pretSeul.GetFinPret());
            Assert.AreEqual(1193.69, pretSeul.GetMensualitée(), 1);
            Assert.AreEqual(24640, pretSeul.GetCoutTotal(), 1);
            Assert.AreEqual(7.72, pretSeul.GetTAEG(), 0.01);
        }

        [Test]
        public void Pret_10_Test()
        { 
            var montantAEmprunter = 110000;
            var dureeEnAnnees = 10;
            var tauxNominal = 1.85 / 100;
            var pretSeul = new Pret("Crédit Test", montantAEmprunter, dureeEnAnnees, tauxNominal, new DateTime(2014, 03, 1));
   
            Assert.AreEqual(montantAEmprunter, pretSeul.MontantAEmprunter);
            Assert.AreEqual(tauxNominal, pretSeul.TauxNominal);
            Assert.AreEqual(dureeEnAnnees, pretSeul.DureeEnAnnees);
            Assert.AreEqual(120, pretSeul.GetDureeEnMois());
            Assert.AreEqual(new DateTime(2024, 3, 1), pretSeul.GetFinPret());
            Assert.AreEqual(1004.77, pretSeul.GetMensualitée(), 0.01);
            Assert.AreEqual(10573, pretSeul.GetCoutTotal(), 1);
            Assert.AreEqual(10.4, pretSeul.GetTAEG(), 0.01);

            var echeances = pretSeul.GetEcheances();
            Assert.AreEqual(120, echeances.Count);
            Assert.AreEqual(835.19, echeances.First().MensualitéDontCapital, 0.01);
            Assert.AreEqual(169.58, echeances.First().MensualitéDontInterets, 0.01);
            Assert.AreEqual(1003.23, echeances.Last().MensualitéDontCapital, 0.01);
            Assert.AreEqual(1.55, echeances.Last().MensualitéDontInterets, 0.01);

             
        }
 
    }
}