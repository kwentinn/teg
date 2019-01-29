using System;
using PretImmo2018.Models;
using PretImmo2018.Services.Interfaces;
using PretImmoWPF.Commands;
using Prism.Commands;
using Prism.Mvvm;

namespace PretImmoWPF.ViewModels
{
	public class PretViewModel : BindableBase
	{
		private IPretService _pretService;
		private IPretCalculator _pretCalculator;
		private IAppCommands _appCommands;

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

			SaveCommand = new DelegateCommand(Save);
			CalculerCommand = new DelegateCommand(Calculate);
		}


		private void Save()
		{
			if (CurrentPret != null)
			{
				_pretService.SaveAsync(CurrentPret);
			}
		}

		private void Calculate()
		{
			if (CurrentPret != null)
			{
				_pretCalculator.LancerCalculs(CurrentPret);
				RaisePropertyChanged(nameof(CurrentPret));
			}
		}
	}
}
