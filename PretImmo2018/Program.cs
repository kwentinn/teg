using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PretImmo2018
{
	class Program
	{
		static void Main(string[] args)
		{
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
			pretSeul.LancerCalculs();
			pretSeul.AfficheRésultats();

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
			pretSeul2.LancerCalculs();
			pretSeul2.AfficheRésultats();

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
			pretSeul3.LancerCalculs();
			pretSeul3.AfficheRésultats();

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
			doublePret.LancerCalculs();
			doublePret.AfficherRésultats();

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
			var doublePret2 = new PretMultiple(new Pret[] { pret3, pret4 });
			doublePret2.LancerCalculs();
			doublePret2.AfficherRésultats();

			Console.ReadLine();
		}
	}
}
