using PretImmo2018.Models;
using System.Threading.Tasks;

namespace PretImmo2018.Services.Interfaces
{
	public interface IPretService
	{
		Task Save(Pret pret);
	}
}
