using PretImmo2018.Model.Base;
using System;
using System.Collections.Generic;

namespace PretImmo2018.Model
{
	public class Pret : IdentifiableObject
	{
		#region  props saisies

		public string Nom { get; set; }

		public double MontantBien { get; set; }
		public double FraisNotariés { get; set; }
		public double Apport { get; set; }
		public int DureeEnAnnees { get; set; }
		public double TauxNominal { get; set; }
		public double TAEG { get; set; }

		public DateTime? DebutPret { get; set; }

		public double FraisDeDossier { get; set; }
		public double FraisDAssurance { get; set; }
		public double FraisDeGarantie { get; set; }
		public double AutresFrais { get; set; }

		public double Mensualités { get; set; }
		public double MontantTotalPret { get; set; }

		public List<Echeance> Echeances { get; private set; }

		#endregion

		#region props calculées

		public int DureeEnMois => DureeEnAnnees * 12;
		public double MontantARembourser => MontantBien + FraisNotariés - Apport;
		public double CoutTotalPret => MontantTotalPret - MontantARembourser;
		public DateTime? FinPret => DebutPret.HasValue ? DebutPret.Value.AddYears(DureeEnAnnees) : (DateTime?)null;

		#endregion

		public Pret()
		{
			Echeances = new List<Echeance>();
		}
	}
}
