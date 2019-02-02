using PretImmo2018.Models;
using PretImmo2018.Services.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PretImmo2018.Services
{
	public class PretService : IPretService
	{
		private readonly IRepository<Pret> _pretRepository;

		public ObservableCollection<Pret> Prets { get; private set; }


		public PretService(IRepository<Pret> pretRepo)
		{
			_pretRepository = pretRepo;

			Prets = new ObservableCollection<Pret>();
		}

		public void Add(Pret pret)
		{
			// choper le max id + 1 pour le nouvel id
			var id = 0;
			var prets = _pretRepository.GetAll();
			if (prets.Any())
			{
				id = prets.Max(p => p.Id) + 1;
			}
			pret.Id = id;

			Prets.Add(pret);
		}

		public IEnumerable<Pret> GetAll()
		{
			Prets.Clear();
			var prets = _pretRepository.GetAll();
			foreach (var p in prets)
			{
				Prets.Add(p);
			}
			return prets;
		}

		public void Remove(int id)
		{
			var removedItem = _pretRepository.Remove(id);
			if (removedItem != null)
			{
				Prets.Remove(removedItem);
			}
		}

		public void Save()
		{
			_pretRepository.Save();
		}

		public Pret Get(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}
