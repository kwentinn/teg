using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PretImmo2018.Services
{
	/// <summary>
	/// Service qui trie les prêts par ordre de pertinence.
	/// </summary>
	public class PretComparer
	{
		public IEnumerable<Pret> Sort(IEnumerable<Pret> prets, bool ascending)
		{
			return ascending ? 
				prets.OrderBy(pret => pret.CoutTotalPret) : 
				prets.OrderByDescending(p => p.CoutTotalPret);
		}

		public Pret GetBest(IEnumerable<Pret> prets)
		{
			var min = prets.Min(p => p.CoutTotalPret);
			return prets.FirstOrDefault(p => p.CoutTotalPret == min);
		}
	}
}
