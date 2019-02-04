using PretImmo2018.DAL;
using PretImmo2018.Model;
using PretImmo2018.Services.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PretImmo2018.Services
{
	public class PretService : IPretService
	{
		private readonly IRepository<Pret> _pretRepository;

		public ObservableCollection<Pret> Prets { get; private set; } = new ObservableCollection<Pret>();

		public PretService(IRepository<Pret> pretRepo)
		{
			_pretRepository = pretRepo;

			var list = _pretRepository.GetAll();

			Prets.AddRange(list);
		}

		public void Add(Pret pret)
		{
			_pretRepository.Add(pret);
			Prets.Add(pret);
		}

		public Pret Get(int id)
		{
			return Prets.FirstOrDefault(p => id == p.ID);
		}

		public IEnumerable<Pret> GetAll()
		{
			return Prets;
		}

		public void Remove(int id)
		{
			_pretRepository.Remove(id);

			var removedItem = Prets.FirstOrDefault(p => id == p.ID);
			if (removedItem != null)
			{
				Prets.Remove(removedItem);
			}
		}

		public void Save()
		{
			_pretRepository.Save();
		}
	}
}
