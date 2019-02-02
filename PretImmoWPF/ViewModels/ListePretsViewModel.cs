using PretImmo2018.Models;
using PretImmo2018.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace PretImmoWPF.ViewModels
{
	public class ListePretsViewModel : BindableBase
	{
		private readonly IPretService _pretService;

		public DelegateCommand OnLoadedCommand { get; private set; }
		public DelegateCommand AddPretCommand { get; private set; }
		public DelegateCommand RemovePretCommand { get; private set; }

		public ObservableCollection<Pret> Prets { get; private set; }

		private Pret _selectedPret;
		public Pret SelectedPret
		{
			get { return _selectedPret; }
			set
			{
				SetProperty(ref _selectedPret, value);
			}
		}

		public ListePretsViewModel(IPretService pretService)
		{
			_pretService = pretService;

			OnLoadedCommand = new DelegateCommand(OnLoad);
			AddPretCommand = new DelegateCommand(AddPret);
			RemovePretCommand = new DelegateCommand(RemovePret);

			Prets = new ObservableCollection<Pret>();
		}

		private void RemovePret()
		{
			if (SelectedPret != null)
			{
				_pretService.Remove(SelectedPret.Id);
				Prets.Remove(SelectedPret);
				SelectedPret = null;
			}
		}

		private void OnLoad()
		{
			Prets.Clear();

			var prets = _pretService.GetAll();

			Prets.AddRange(prets);
		}

		private void AddPret()
		{
			SelectedPret = new Pret();
			_pretService.Add(SelectedPret);
			Prets.Add(SelectedPret);
		}
	}
}
