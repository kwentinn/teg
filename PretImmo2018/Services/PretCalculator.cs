using PretImmo2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
			pretMultiple.Prets.ForEach(pret => LancerCalculs(pret));
			EtablirEcheancier(pretMultiple);
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
			pretMultiple.Prets.ForEach(pret => AfficheRésultats(pret));

			Console.WriteLine($"Montant total de {pretMultiple.MontantTotalPret.ToString("N2")}");
			Console.WriteLine($"Coût total de {pretMultiple.CoutTotalPret.ToString("N2")}");
		}

		#endregion

		#region Méthodes privées

		private double CalculerMontantTotalPret(Pret pret)
		{
			var va = 0.0; // valeur actualisée
			var mensualité = this.CalculRemboursementMensuel(pret.MontantARembourser, pret.TAEG, pret.DureeEnMois); // la mensualité
			for (int t = 1; t <= pret.DureeEnMois; t++)
			{
				va += mensualité;
				pret.Echeances.Add(new Echeance
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
		private void EtablirEcheancier(PretMultiple pretMultiple)
		{
			pretMultiple.DureeEnAnnees = pretMultiple.Prets.Max(p => p.DureeEnAnnees);
			for (var t = 1; t <= pretMultiple.DureeEnMois; t++)
			{
				var ech = new Echeance()
				{
					Id = t,
					Date = pretMultiple.DebutPret.AddMonths(t)
				};
				foreach (var pret in pretMultiple.Prets)
				{
					if (t < pret.Echeances.Count)
					{
						var subEch = pret.Echeances[t];
						if (subEch != null)
						{
							ech.CapitalRemboursé += subEch.CapitalRemboursé;
							ech.CapitalRestantDû += subEch.CapitalRestantDû;
							ech.Montant += subEch.Montant;
							ech.IntérêtsPayés += subEch.IntérêtsPayés;
							ech.MontantDesFrais += subEch.MontantDesFrais;
						}
					}
				}
				pretMultiple.Echeances.Add(ech);
			}
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
