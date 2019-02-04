using PretImmo2018.DAL;
using PretImmo2018.Model;
using PretImmo2018.Services;
using PretImmo2018.Services.Interfaces;
using PretImmoWPF.Commands;
using PretImmoWPF.Config;
using PretImmoWPF.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System.Globalization;
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
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("fr-FR");
			CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("fr-FR");

			return Container.Resolve<MainWindow>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<IPretCalculator, PretCalculator>();
			containerRegistry.RegisterSingleton<IPretComparer, PretComparer>();

			// on indique comment sont sérialisés les classes (Pret en l'occurence).
			containerRegistry.RegisterSingleton<IRepository<Pret>, JsonRepository<Pret>>();
			containerRegistry.RegisterSingleton<IPretService, PretService>();

			// services
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
