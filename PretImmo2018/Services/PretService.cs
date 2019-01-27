using PretImmo2018.Models;
using PretImmo2018.Services.Interfaces;
using System.Threading.Tasks;

namespace PretImmo2018.Services
{
	public class PretService : IPretService
	{
		ISerializer<Pret> _serializer;

		public PretService(ISerializer<Pret> serializer)
		{
			_serializer = serializer;
		}

		public async Task Save(Pret pret)
		{
			await _serializer.SerializeObject(pret);
		}
	}
}
