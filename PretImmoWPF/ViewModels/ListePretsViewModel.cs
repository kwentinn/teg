using PretImmo2018.Models;
using PretImmo2018.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace PretImmoWPF.ViewModels
{
	public class ListePretsViewModel : BindableBase
	{
		private readonly IPretService _pretService;

		public DelegateCommand OnLoadedCommand { get; private set; }

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

			Prets = new ObservableCollection<Pret>();
		}

		private async void OnLoad()
		{
			Prets.Clear();

			var prets = await _pretService.GetAllAsync();

			Prets.AddRange(prets);
		}
	}
}
