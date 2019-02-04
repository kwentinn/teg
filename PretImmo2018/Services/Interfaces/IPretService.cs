using PretImmo2018.Model;
using System.Collections.Generic;

namespace PretImmo2018.Services.Interfaces
{
	/// <summary>
	/// Contrat du service de prêt
	/// </summary>
	public interface IPretService
	{
		void Add(Pret pret);
		void Save();
		Pret Get(int id);
		IEnumerable<Pret> GetAll();
		void Remove(int id);
	}
}
