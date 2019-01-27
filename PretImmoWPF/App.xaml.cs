using PretImmoWPF.ViewModels;
using PretImmoWPF.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;

namespace PretImmoWPF
{
	/// <summary>
	/// Logique d'interaction pour App.xaml
	/// </summary>
	public partial class App : PrismApplication
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<PretView>();
			
		}
	}
}
