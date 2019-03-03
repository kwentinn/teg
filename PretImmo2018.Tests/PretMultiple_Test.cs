using NUnit.Framework;
using PretImmo2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class PretMultipleTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PretMultiple_Test()
        { 
            var montantBien = 263000;
            var apport = 91186;
            var fraisDeGarantie = 2500;
            var montantAEmprunter = montantBien - apport + fraisDeGarantie;
            var dureeEnAnnees = 15;
            var tauxNominal = 1.50 / 100;

            var pret_1 = new Pret("Crédit Test (teg de 1,50%)", montantAEmprunter, dureeEnAnnees, tauxNominal, new DateTime(2018, 12, 1));
        
            var pret_2 = new Pret("Crédit pour frais de notaire", 19300, 4, 0.946/100, new DateTime(2018, 12, 1));

            var doublePret = new PretMultiple("Prêt composé d'1 crédit appart + 1 crédit pour frais d'acte de vente", new List<Pret> { pret_1, pret_2 });

            Assert.AreEqual(20453.55, pret_1.GetCoutTotal(), 0.01);
            Assert.AreEqual(375.06, pret_2.GetCoutTotal(), 0.01);
            Assert.AreEqual(20828.62, doublePret.GetCoutTotal(), 0.01);
        }

    }
}