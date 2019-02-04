using PretImmo2018.Model;
using System.Collections.Generic;

namespace PretImmo2018.Services.Interfaces
{
	public interface IPretComparer
	{
		IEnumerable<Pret> Sort(IEnumerable<Pret> prets, bool ascending);
		Pret GetBest(IEnumerable<Pret> prets);
	}
}
