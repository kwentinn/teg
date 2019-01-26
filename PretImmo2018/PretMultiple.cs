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
	}
}