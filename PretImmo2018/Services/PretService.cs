using PretImmo2018.Models;
using PretImmo2018.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

		public async Task Add(Pret pret)
		{
			// choper le max id + 1 pour le nouvel id
			var id = 1;
			var prets = await _serializer.DeserializeAll();
			if (prets.Any())
			{
				id = prets.Select(p => p.Id).Max() + 1;
			}
			pret.Id = id;
			await SaveAsync(pret);
		}

		public async Task<IEnumerable<Pret>> GetAllAsync()
		{
			return await _serializer.DeserializeAll();
		}

		public async Task Remove(int id)
		{
			var list = (List<Pret>)await _serializer.DeserializeAll();
			if (!list.Any())
				return;

			var pret = list.FirstOrDefault(p => p.Id == id);
			if (pret != null)
			{
				list.Remove(pret);
			}

		}

		public async Task SaveAsync(Pret pret)
		{
			await _serializer.SerializeObject(pret);
		}
	}
}
