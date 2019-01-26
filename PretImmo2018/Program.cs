using PretImmo2018.Models;
using PretImmo2018.Services;
using System;
using System.Collections.Generic;

namespace PretImmo2018
{
	class Program
	{
		static void Main(string[] args)
		{
			var pretCalculator = new PretCalculator();

			// ------------------------- //
			var pretSeul = new Pret
			{
				Nom = "Crédit immo appart Carnon (teg de 1,50%)",
				MontantBien = 263000,
				Apport = 91186,
				DureeEnAnnees = 15,
				FraisNotariés = 18410,
				TAEG = 1.50 / 100,
				FraisDeGarantie = 2413,
				DebutPret = new DateTime(2018, 12, 1)
			};
			pretCalculator.LancerCalculs(pretSeul);
			pretCalculator.AfficheRésultats(pretSeul);
			// ------------------------- //
			var pretSeul2 = new Pret
			{
				Nom = "Crédit immo appart Carnon (teg de 1,65%)",
				MontantBien = 263000,
				Apport = 91186,
				DureeEnAnnees = 15,
				FraisNotariés = 18410,
				TAEG = 1.65 / 100,
				FraisDeGarantie = 2413,
				DebutPret = new DateTime(2018, 12, 1)
			};
			pretCalculator.LancerCalculs(pretSeul2);
			pretCalculator.AfficheRésultats(pretSeul2);
			// ------------------------- //
			var pretSeul3 = new Pret
			{
				Nom = "Crédit immo sans frais de notaire (teg de 1,65%)",
				MontantBien = 263000,
				Apport = 91186,
				DureeEnAnnees = 15,
				FraisNotariés = 0,
				TAEG = 1.65 / 100,
				FraisDeGarantie = 2413,
				DebutPret = new DateTime(2018, 12, 1)
			};
			pretCalculator.LancerCalculs(pretSeul3);
			pretCalculator.AfficheRésultats(pretSeul3);
			// ------------------------- //
			var pret = new Pret
			{
				Nom = "Crédit immo appart Carnon",
				MontantBien = 263000,
				Apport = 91186,
				DureeEnAnnees = 15,
				//FraisNotariés = 19300,
				TAEG = 1.5 / 100,
				FraisDeGarantie = 2500,
				DebutPret = new DateTime(2018, 12, 1)
			};
			var pret2 = new Pret
			{
				Nom = "Crédit pour frais de notaire",
				MontantBien = 19300,
				Apport = 0,
				DureeEnAnnees = 4,
				TAEG = 0.946 / 100,
				DebutPret = new DateTime(2018, 12, 1)
			};
			var doublePret = new PretMultiple(new Pret[] { pret, pret2 });
			pretCalculator.LancerCalculs(doublePret);
			pretCalculator.AfficherRésultats(doublePret);
			// ------------------------- //
			var pret3 = new Pret
			{
				Nom = "Crédit immo appart Carnon (1,52%)",
				MontantBien = 263000,
				Apport = 91186,
				DureeEnAnnees = 14,
				FraisNotariés = 0,
				TAEG = 1.520 / 100,
				FraisDeGarantie = 2500,
				DebutPret = new DateTime(2018, 12, 1)
			};
			var pret4 = new Pret
			{
				Nom = "Crédit pour frais de notaire",
				MontantBien = 19300,
				Apport = 0,
				DureeEnAnnees = 4,
				TAEG = 0.946 / 100,
				DebutPret = new DateTime(2018, 12, 1)
			};
			var doublePret2 = new PretMultiple(new Pret[] { pret3, pret4 })
			{
				Nom = "Double prêt"
			};
			pretCalculator.LancerCalculs(doublePret2);
			pretCalculator.AfficherRésultats(doublePret2);

			var comp = new PretComparer();
			var best = comp.GetBest(new List<Pret> { pretSeul, pretSeul2, pretSeul3 });

			Console.ReadLine();
		}
	}
}
