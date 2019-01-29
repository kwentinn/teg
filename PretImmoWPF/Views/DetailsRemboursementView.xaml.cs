using PretImmo2018.Models;
using PretImmoWPF.ViewModels;
using Prism.Common;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PretImmoWPF.Views
{
	/// <summary>
	/// Logique d'interaction pour DetailsRemboursementView.xaml
	/// </summary>
	public partial class DetailsRemboursementView : UserControl
	{
		public DetailsRemboursementView()
		{
			InitializeComponent();
			RegionContext.GetObservableContext(this).PropertyChanged += SelectedPret_PropertyChanged;
		}

		private void SelectedPret_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var context = (ObservableObject<object>)sender;
			var selectedPret = (Pret)context.Value;
			(DataContext as DetailsRemboursementViewModel).CurrentPret = selectedPret;
		}
	}
}
