using PretImmo2018.Model.Base;
using PretImmo2018.Model.Interfaces;
using System;

namespace PretImmo2018.Model
{
	public class Echeance: IdentifiableObject
	{
		#region IIdentifiable

		public int ID { get; set; }

		#endregion

		public DateTime	Date { get; set; }
		public double Montant { get; set; }

		public double CapitalRestantDû { get; set; }
		public double IntérêtsPayés { get; set; }
		public double CapitalRemboursé { get; set; }
		public double MontantDesFrais { get; set; }

		public override string ToString()
		{
			return $"En {Date.Year}: Mensualité de {Montant.ToString("C")} - Capital remboursé: {CapitalRemboursé.ToString("C")}";
		}
	}
}
