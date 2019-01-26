using System.Collections.Generic;
using System.Linq;

namespace PretImmo2018.Models
{
	public class PretMultiple : Pret
	{
		#region Propriétés

		public List<Pret> Prets { get; private set; }

		public new double MontantTotalPret
		{
			get
			{
				if (!Prets.Any())
					return 0d;
				return Prets.Select(p => p.MontantTotalPret).Sum();
			}
		}
		public new double CoutTotalPret
		{
			get
			{
				if (!Prets.Any())
					return 0d;
				return Prets.Select(p => p.CoutTotalPret).Sum();
			}
		}

		#endregion

		#region constructeurs

		public PretMultiple()
		{
			Prets = new List<Pret>();
		}
		public PretMultiple(IEnumerable<Pret> prets)
		{
			Prets = prets.ToList();
		}

		#endregion
	}
}