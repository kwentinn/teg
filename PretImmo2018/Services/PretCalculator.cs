using System;
using System.Collections.Generic;

namespace PretImmo2018.Services
{
	/// <summary>
	/// classe de calcul du prêt
	/// </summary>
	public class PretCalculator
	{
		#region Méthodes publiques

		/// <summary>
		/// Lance les calculs
		/// </summary>
		public void LancerCalculs(Pret pret)
		{
			pret.Mensualités = CalculerEcheance(pret);
			pret.MontantTotalPret = CalculerMontantTotalPret(pret);
		}
		public void LancerCalculs(PretMultiple pretMultiple)
		{
			pretMultiple.ForEach(pret => LancerCalculs(pret));
		}

		/// <summary>
		/// Affiche les résultats dans la console.
		/// </summary>
		public void AfficheRésultats(Pret pret)
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
		public void AfficherRésultats(PretMultiple pretMultiple)
		{
			pretMultiple.ForEach(pret => AfficheRésultats(pret));

			Console.WriteLine($"Montant total de {pretMultiple.MontantTotalPret.ToString("N2")}");
			Console.WriteLine($"Coût total de {pretMultiple.CoutTotalPret.ToString("N2")}");
		}

		#endregion

		#region Méthodes privées

		private double CalculerMontantTotalPret(Pret pret)
		{
			var echeances = new List<Echeance>(); // les échéances de remboursement
			var va = 0.0; // valeur actualisée
			var mensualité = this.CalculRemboursementMensuel(pret.MontantARembourser, pret.TAEG, pret.DureeEnMois); // la mensualité
			for (int t = 1; t <= pret.DureeEnMois; t++)
			{
				va += mensualité;
				echeances.Add(new Echeance
				{
					Id = t,
					Date = pret.DebutPret.AddMonths(t),
					Montant = mensualité,
					CapitalRemboursé = va
				});
			}
			return va;
		}
		private double CalculerEcheance(Pret pret)
		{
			return CalculRemboursementMensuel(pret.MontantARembourser, pret.TAEG, pret.DureeEnMois);
		}
		private double CalculRemboursementMensuel(double montantEmprunte, double tauxAnnuel, int nbEcheances)
		{
			var remboursementMensuel = 0.0;
			if (tauxAnnuel > 0)
				remboursementMensuel = (montantEmprunte * tauxAnnuel / 12) / (1 - Math.Pow(1 + tauxAnnuel / 12, -nbEcheances));
			else
				remboursementMensuel = montantEmprunte / nbEcheances;

			return remboursementMensuel;
		}

		#endregion
	}
}
