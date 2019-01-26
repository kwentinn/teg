using System;
using System.Collections.Generic;

namespace PretImmo2018
{
	public class Pret
	{
		#region  props saisies 

		public string Nom { get; set; }

		public double MontantBien { get; set; }
		public double FraisNotariés { get; set; }
		public double Apport { get; set; }
		public int DureeEnAnnees { get; set; }
		public double TauxNominal { get; set; }
		public double TAEG { get; set; }

		public DateTime DebutPret { get; set; }

		public double FraisDeDossier { get; set; }
		public double FraisDAssurance { get; set; }
		public double FraisDeGarantie { get; set; }
		public double AutresFrais { get; set; }

		public double Mensualités { get; set; }
		public double MontantTotalPret { get; set; }

		#endregion

		#region props calculées

		public int DureeEnMois { get => DureeEnAnnees * 12; }
		public double MontantARembourser { get => MontantBien + FraisNotariés - Apport; }
		public double CoutTotalPret => MontantTotalPret - MontantARembourser;

		#endregion

		#region Méthodes publiques

		/// <summary>
		/// Lance les calculs
		/// </summary>
		public void LancerCalculs()
		{
			Mensualités = CalculerEcheance();
			MontantTotalPret = CalculerMontantTotalPret();
		}
		
		/// <summary>
		/// Affiche les résultats dans la console.
		/// </summary>
		public void AfficheRésultats()
		{
			Console.WriteLine("#############################################");
			Console.WriteLine($"CREDIT \"{Nom}\"");
			Console.WriteLine();
			Console.WriteLine($"Montant du bien: {MontantBien.ToString("N2")}");
			Console.WriteLine($"Frais de notaire: {FraisNotariés.ToString("N2")}");
			Console.WriteLine($"Montant apport: {Apport.ToString("N2")}");
			Console.WriteLine($"TAEG: {TAEG.ToString("P3")}");
			Console.WriteLine($"MontantARembourser: {MontantARembourser.ToString("N2")}");
			Console.WriteLine($"Mensualités de {Mensualités.ToString("N2")} sur {DureeEnAnnees} ans");
			Console.WriteLine($"Montant total du prêt {MontantTotalPret.ToString("N2")}");
			Console.WriteLine($"Coût du prêt {CoutTotalPret.ToString("N2")}");
			Console.WriteLine("#############################################");
			Console.WriteLine();
		}

		#endregion

		#region Méthodes privées

		private double CalculerMontantTotalPret()
		{
			var echeances = new List<Echeance>(); // les échéances de remboursement
			var va = 0.0; // valeur actualisée
			var mensualité = this.CalculRemboursementMensuel(MontantARembourser, TAEG, DureeEnMois); // la mensualité
			for (int t = 1; t <= DureeEnMois; t++)
			{
				va += mensualité;
				echeances.Add(new Echeance { Id = t, Date = DebutPret.AddMonths(t), Montant = mensualité, CapitalRemboursé = va });
			}
			return va;
		}
		private double CalculerEcheance()
		{
			return CalculRemboursementMensuel(MontantARembourser, TAEG, DureeEnMois);
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
