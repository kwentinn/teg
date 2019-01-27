using PretImmoWPF.Views;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			_regionManager.RegisterViewWithRegion("ContentRegion", typeof(PretView));
		}
	}
}
