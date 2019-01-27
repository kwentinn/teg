using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PretImmoWPF.ViewModels
{
	public class PretViewModel : BindableBase
	{
		public DelegateCommand SaveCommand { get; private set; }

		public PretViewModel()
		{
			SaveCommand = new DelegateCommand(Save);
		}

		private void Save()
		{
			throw new NotImplementedException();
		}
	}
}
