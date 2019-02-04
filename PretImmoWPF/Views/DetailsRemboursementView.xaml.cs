using PretImmo2018.Model;
using PretImmoWPF.ViewModels;
using Prism.Common;
using Prism.Regions;
using System.ComponentModel;
using System.Windows.Controls;

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
