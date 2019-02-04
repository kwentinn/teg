using PretImmo2018.DAL;
using PretImmo2018.Model;
using PretImmo2018.Services.Interfaces;
using PretImmoWPF.Commands;
using Prism.Commands;
using Prism.Mvvm;

namespace PretImmoWPF.ViewModels
{
	public class PretViewModel : BindableBase
	{
		private readonly IRepository<Pret> _pretRepository;
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

		public PretViewModel(IRepository<Pret> pretRepository,
			IPretCalculator pretCalculator,
			IAppCommands appCommands)
		{
			_pretRepository = pretRepository;
			_pretCalculator = pretCalculator;
			_appCommands = appCommands;

			SaveCommand = new DelegateCommand(Save);
			CalculerCommand = new DelegateCommand(Calculate);
		}

		private void Save()
		{
			if (CurrentPret == null)
				return;

			//_pretRepository.Add(CurrentPret);
			_pretRepository.Save();
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
