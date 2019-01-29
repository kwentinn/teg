using PretImmo2018.Models;
using Prism.Mvvm;
using System.Collections.Generic;

namespace PretImmoWPF.ViewModels
{
	public class DetailsRemboursementViewModel : BindableBase
	{
		private Pret _currentPret;
		public Pret CurrentPret
		{
			get => _currentPret;
			set
			{
				SetProperty(ref _currentPret, value);
			}
		}

		public DetailsRemboursementViewModel()
		{
		}
	}
}
