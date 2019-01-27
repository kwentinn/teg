using PretImmo2018.Models;
using PretImmo2018.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PretImmo2018.Services
{
	/// <summary>
	/// Service qui trie les prêts par ordre de pertinence.
	/// </summary>
	public class PretComparer : IPretComparer
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
