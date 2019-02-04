using PretImmo2018.Model;
using PretImmo2018.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;

namespace PretImmoWPF.ViewModels
{
	public class ListePretsViewModel : BindableBase
	{
		public IPretService PretService { get; private set; }

		public DelegateCommand OnLoadedCommand { get; private set; }
		public DelegateCommand AddPretCommand { get; private set; }
		public DelegateCommand RemovePretCommand { get; private set; }

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
			PretService = pretService;

			OnLoadedCommand = new DelegateCommand(OnLoad);
			AddPretCommand = new DelegateCommand(AddPret);
			RemovePretCommand = new DelegateCommand(RemovePret);
		}

		private void RemovePret()
		{
			if (SelectedPret != null)
			{
				PretService.Remove(SelectedPret.ID);
				SelectedPret = null;
			}
		}

		private void OnLoad()
		{
			//var prets = PretService.GetAll();
		}

		private void AddPret()
		{
			SelectedPret = new Pret();
			PretService.Add(SelectedPret);
		}
	}
}
