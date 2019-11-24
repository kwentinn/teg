using System;

namespace PretImmo2018.Models
{
	public class Echeance : IComparable<Echeance>
	{
        public Echeance(DateTime date, double mensualité)
        {
            Date = date;
            Mensualité = mensualité;
        }     
        public DateTime	Date { get; private set; }  
		public double CapitalRestantDû { get; private set; }
        public double Mensualité { get; private set; }
        public double MensualitéDontCapital { get { return Mensualité - MensualitéDontInterets; } }
        public double MensualitéDontInterets { get; set; } 

        public int CompareTo(Echeance other)
        {
            return Date.CompareTo(other.Date);
        }

        public override string ToString()
		{
			return $"En {Date.Year}/{Date.Month}: {CapitalRestantDû.ToString("C")} {Mensualité.ToString("C")} {MensualitéDontCapital.ToString("C")} {MensualitéDontInterets.ToString("C")} ";
		}
	}
}
