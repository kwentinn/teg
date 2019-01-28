using PretImmo2018.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PretImmo2018.Services.Interfaces
{
	public interface IPretService
	{
		Task Save(Pret pret);
		Task<IEnumerable<Pret>> GetAllAsync();

		Pret SelectedPret { get; set; }
		IEnumerable<Pret> AllPrets { get; set; }
	}
}
