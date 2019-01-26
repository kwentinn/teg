using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PretImmo2018
{
	public class PretMultiple : List<Pret>
	{
		#region Propriétés

		public double MontantTotalPret
		{
			get
			{
				if (!this.Any()) return 0d;
				return this.Select(p => p.MontantTotalPret).Sum();
			}
		}
		public double CoutTotalPret
		{
			get
			{
				if (!this.Any()) return 0d;
				return this.Select(p => p.CoutTotalPret).Sum();
			}
		}

		#endregion

		#region constructeurs

		public PretMultiple()
		{
		}
		public PretMultiple(int capacity) : base(capacity)
		{
		}
		public PretMultiple(IEnumerable<Pret> collection) : base(collection)
		{
		}

		#endregion

		public void AfficherRésultats()
		{
			ForEach(p => p.AfficheRésultats());

			Console.WriteLine($"Montant total de {MontantTotalPret.ToString("N2")}");
			Console.WriteLine($"Coût total de {CoutTotalPret.ToString("N2")}");
		}

		public void LancerCalculs()
		{
			ForEach(p => p.LancerCalculs());
		}
	}
}