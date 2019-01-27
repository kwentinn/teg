using PretImmo2018.Models;
using PretImmo2018.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;

namespace PretImmoWPF.ViewModels
{
	public class PretViewModel : BindableBase
	{
		private IPretService _pretService;
		private IPretCalculator _pretCalculator;

		public DelegateCommand SaveCommand { get; private set; }
		public DelegateCommand CalculerCommand { get; set; }


		private string _nom;
		public string Nom
		{
			get { return _nom; }
			set { SetProperty(ref _nom, value); }
		}

		public PretViewModel(IPretService pretService, IPretCalculator pretCalculator)
		{
			_pretService = pretService;
			_pretCalculator = pretCalculator;

			SaveCommand = new DelegateCommand(Save);
			CalculerCommand = new DelegateCommand(Calculate);
		}

		private void Save()
		{
			var p = new Pret() { Nom = this.Nom };
			_pretService.Save(p);
		}

		private void Calculate()
		{
			var p = new Pret() { Nom = this.Nom };
			_pretCalculator.LancerCalculs(p);
		}
	}
}
