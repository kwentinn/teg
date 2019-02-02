using PretImmo2018.Exceptions;
using PretImmo2018.Models;
using PretImmo2018.Services.Interfaces;
using System;
using System.Linq;

namespace PretImmo2018.Services
{
	/// <summary>
	/// classe de calcul du prêt
	/// </summary>
	public class PretCalculator : IPretCalculator
	{
		#region Méthodes publiques

		/// <summary>
		/// Lance les calculs
		/// </summary>
		public void LancerCalculs(Pret pret)
		{
			try
			{
				pret.Echeances.Clear();
				pret.Mensualités = CalculerEcheance(pret);
				pret.MontantTotalPret = CalculerMontantTotalPret(pret);
			}
			catch (Exception ex)
			{
				throw new ServiceException("Impossible de lancer les calculs.", ex);
			}
		}
		public void LancerCalculs(PretMultiple pretMultiple)
		{
			pretMultiple.Prets.ForEach(pret => LancerCalculs(pret));
			EtablirEcheancier(pretMultiple);
		}

		#endregion

		#region Méthodes privées

		private double CalculerMontantTotalPret(Pret pret)
		{
			var va = 0.0; // valeur actualisée
			var mensualité = this.CalculRemboursementMensuel(pret.MontantARembourser, pret.TAEG, pret.DureeEnMois); // la mensualité

			var startDate = pret.DebutPret.HasValue ? pret.DebutPret.Value : DateTime.Now;

			for (int t = 1; t <= pret.DureeEnMois; t++)
			{
				va += mensualité;
				pret.Echeances.Add(new Echeance
				{
					ID = t,
					Date = startDate.AddMonths(t),
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

			var startDate = pretMultiple.DebutPret.HasValue ? pretMultiple.DebutPret.Value : DateTime.Now;

			for (var t = 1; t <= pretMultiple.DureeEnMois; t++)
			{
				var ech = new Echeance
				{
					ID = t,
					Date = startDate.AddMonths(t)
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
