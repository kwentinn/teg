using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PretImmo2018
{
	public class Echeance
	{
		public int Id { get; set; }

		public DateTime	Date { get; set; }
		public double Montant { get; set; }
		//public double Total { get; set; }

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
