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
	}
	public class AppCommands : IAppCommands
	{
		public CompositeCommand SelectItemCommand { get; } = new CompositeCommand();
	}
}
