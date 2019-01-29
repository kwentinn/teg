using Prism.Mvvm;
using Prism.Regions;

namespace PretImmoWPF.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private readonly IRegionManager _regionManager;

		private string _title = "Prêt Immo WPF";
		public string Title
		{
			get => _title;
			set => SetProperty(ref _title, value);
		}

		public MainWindowViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;
		}
	}
}
