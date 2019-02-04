using PretImmo2018.Model;
using Prism.Mvvm;

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
