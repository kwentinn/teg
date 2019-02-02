using PretImmo2018.Models;
using PretImmo2018.Services.Interfaces;
using PretImmoWPF.Commands;
using Prism.Commands;
using Prism.Mvvm;

namespace PretImmoWPF.ViewModels
{
	public class PretViewModel : BindableBase
	{
		private readonly IPretService _pretService;
		private readonly IPretCalculator _pretCalculator;
		private readonly IAppCommands _appCommands;

		public DelegateCommand SaveCommand { get; private set; }
		public DelegateCommand CalculerCommand { get; private set; }

		private Pret _currentPret;
		public Pret CurrentPret
		{
			get { return _currentPret; }
			set { SetProperty(ref _currentPret, value); }
		}

		private string _nom;
		public string Nom
		{
			get { return _nom; }
			set { SetProperty(ref _nom, value); }
		}

		public PretViewModel(IPretService pretService, IPretCalculator pretCalculator, IAppCommands appCommands)
		{
			_pretService = pretService;
			_pretCalculator = pretCalculator;
			_appCommands = appCommands;

			SaveCommand = new DelegateCommand(Save);
			CalculerCommand = new DelegateCommand(Calculate);
		}

		private void Save()
		{
			if (CurrentPret == null)
				return;

			_pretService.Add(CurrentPret);
			_pretService.Save();
		}

		private void Calculate()
		{
			if (CurrentPret == null)
				return;

			_pretCalculator.LancerCalculs(CurrentPret);
			RaisePropertyChanged(nameof(CurrentPret));
		}
	}
}
