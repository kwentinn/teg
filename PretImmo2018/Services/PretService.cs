using PretImmo2018.Models;
using PretImmo2018.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PretImmo2018.Services
{
	public class PretService : IPretService
	{
		ISerializer<Pret> _serializer;

		public Pret SelectedPret { get; set; }
		public IEnumerable<Pret> AllPrets { get; set; }

		public PretService(ISerializer<Pret> serializer)
		{
			_serializer = serializer;
			SelectedPret = null;
			AllPrets = new List<Pret>();
		}

		public async Task<IEnumerable<Pret>> GetAllAsync()
		{
			AllPrets = await _serializer.DeserializeAll();
			return AllPrets;
		}
		public async Task Save(Pret pret)
		{
			await _serializer.SerializeObject(pret);

			// on remet à jour la liste pour la garder à jour en mémoire
			AllPrets = await _serializer.DeserializeAll();
		}
	}
}
