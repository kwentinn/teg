using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PretImmoWPF.Commands
{
	public interface IAppCommands
	{
		CompositeCommand SelectItemCommand { get; }
		CompositeCommand SaveItemCommand { get; }
	}
	public class AppCommands : IAppCommands
	{
		public CompositeCommand SaveItemCommand { get; } = new CompositeCommand();
		public CompositeCommand SelectItemCommand { get; } = new CompositeCommand();
	}
}
