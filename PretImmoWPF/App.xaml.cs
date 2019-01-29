using PretImmo2018.Models;
using PretImmo2018.Services;
using PretImmo2018.Services.Interfaces;
using PretImmoWPF.Commands;
using PretImmoWPF.Config;
using PretImmoWPF.ViewModels;
using PretImmoWPF.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
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
			containerRegistry.RegisterSingleton<IPretCalculator, PretCalculator>();
			containerRegistry.RegisterSingleton<IPretComparer, PretComparer>();

			// on indique comment sont sérialisés les classes (Pret en l'occurence).
			containerRegistry.RegisterSingleton<ISerializer<Pret>, JsonSerializer<Pret>>();

			// services
			containerRegistry.RegisterSingleton<IPretService, PretService>();
			containerRegistry.RegisterSingleton<IAppCommands, AppCommands>();

			// nav
			//containerRegistry.RegisterForNavigation<PretView>();
		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<PretImmo2018.PretImmo2018Module>();
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			var regionManager = this.Container.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(ListePretsView));
			regionManager.RegisterViewWithRegion(RegionNames.ActionRegion, typeof(PretView));
			regionManager.RegisterViewWithRegion(RegionNames.DetailsRegion, typeof(DetailsRemboursementView));

		}
	}
}
