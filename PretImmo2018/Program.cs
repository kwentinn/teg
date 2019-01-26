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
			AfficheRésultats(pretSeul);
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
			AfficheRésultats(pretSeul2);
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
			AfficheRésultats(pretSeul3);
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
			var doublePret = new PretMultiple(new Pret[] { pret, pret2 })
			{
				Nom = "Prêt composé d'1 crédit appart + 1 crédit pour frais d'acte de vente",
				DebutPret = new DateTime(2019, 2, 1)
			};
			pretCalculator.LancerCalculs(doublePret);
			AfficherRésultats(doublePret);
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
				Nom = "Double prêt 1.52% + 0.946%",
				DebutPret = new DateTime(2019, 2, 1)
			};
			pretCalculator.LancerCalculs(doublePret2);
			AfficherRésultats(doublePret2);

			var comp = new PretComparer();
			var best = comp.GetBest(new List<Pret> { pretSeul, pretSeul2, pretSeul3 });

			Console.ReadLine();
		}

		/// <summary>
		/// Affiche les résultats dans la console.
		/// </summary>
		public static void AfficheRésultats(Pret pret)
		{
			Console.WriteLine("#############################################");
			Console.WriteLine($"CREDIT \"{pret.Nom}\"");
			Console.WriteLine();
			Console.WriteLine($"Montant du bien: {pret.MontantBien.ToString("N2")}");
			Console.WriteLine($"Frais de notaire: {pret.FraisNotariés.ToString("N2")}");
			Console.WriteLine($"Montant apport: {pret.Apport.ToString("N2")}");
			Console.WriteLine($"TAEG: {pret.TAEG.ToString("P3")}");
			Console.WriteLine($"MontantARembourser: {pret.MontantARembourser.ToString("N2")}");
			Console.WriteLine($"Mensualités de {pret.Mensualités.ToString("N2")} sur {pret.DureeEnAnnees} ans");
			Console.WriteLine($"Montant total du prêt {pret.MontantTotalPret.ToString("N2")}");
			Console.WriteLine($"Coût du prêt {pret.CoutTotalPret.ToString("N2")}");
			Console.WriteLine("#############################################");
			Console.WriteLine();
		}
		public static void AfficherRésultats(PretMultiple pretMultiple)
		{
			pretMultiple.Prets.ForEach(pret => AfficheRésultats(pret));

			Console.WriteLine($"Montant total de {pretMultiple.MontantTotalPret.ToString("N2")}");
			Console.WriteLine($"Coût total de {pretMultiple.CoutTotalPret.ToString("N2")}");
		}
	}
}
