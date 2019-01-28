using PretImmo2018.Models;
using PretImmo2018.Services.Interfaces;
using PretImmoWPF.Commands;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace PretImmoWPF.ViewModels
{
	public class ListePretsViewModel : BindableBase
	{
		private readonly IPretService _pretService;

		private IAppCommands _appCommands;
		public  IAppCommands AppCommands
		{
			get { return _appCommands; }
			set { SetProperty(ref _appCommands, value); }
		}

		public DelegateCommand OnLoadedCommand { get; private set; }
		public DelegateCommand SelectItemCommand { get; private set; }

		public ObservableCollection<Pret> Prets { get; private set; }

		private Pret _selectedPret;
		public Pret SelectedPret
		{
			get { return _selectedPret; }
			set
			{ 
				SetProperty(ref _selectedPret, value);
				_pretService.SelectedPret = value;
			}
		}

		public ListePretsViewModel(IPretService pretService, IAppCommands appCommands)
		{
			_pretService = pretService;
			_appCommands = appCommands;

			OnLoadedCommand = new DelegateCommand(OnLoad);
			SelectItemCommand = new DelegateCommand(SelectItem);

			_appCommands.SelectItemCommand.RegisterCommand(SelectItemCommand);

			Prets = new ObservableCollection<Pret>();
		}

		private void SelectItem()
		{
			MessageBox.Show("C'est un succès!");
		}

		private async void OnLoad()
		{
			Prets.Clear();

			var prets = await _pretService.GetAllAsync();

			Prets.AddRange(prets);

		}
	}
}
