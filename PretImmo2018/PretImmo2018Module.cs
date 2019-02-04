using Prism.Ioc;
using Prism.Modularity;
using System;

namespace PretImmo2018
{
	public class PretImmo2018Module : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			Console.WriteLine("PretImmo2018Module.OnInitialized");
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			Console.WriteLine("PretImmo2018Module.RegisterTypes");
		}
	}
}
