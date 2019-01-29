using PretImmo2018.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PretImmo2018.Services.Interfaces
{
	/// <summary>
	/// Contrat du service de prêt
	/// </summary>
	public interface IPretService
	{
		Task Add(Pret pret);
		Task SaveAsync(Pret pret);
		Task<IEnumerable<Pret>> GetAllAsync();
		Task Remove(int id);
	}
}
