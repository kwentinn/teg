using PretImmo2018.Services.Interfaces;
using System;

namespace PretImmo2018.Models
{
	public class Echeance: IIdentifiable
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
