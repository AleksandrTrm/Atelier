using Atelier.Model;
using System.Windows;
using System.Windows.Controls;

namespace Atelier.View
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class Clients : UserControl
	{
		public Clients()
		{
			InitializeComponent();            
		}

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
			DeleteClientBtn.Visibility = Visibility.Collapsed;
            AddClientBtn.Visibility = Visibility.Collapsed;
            ClientsDataGrid.Visibility = Visibility.Collapsed;
            SaveBtn.Visibility = Visibility.Collapsed;
            ReturnBtn.Visibility = Visibility.Visible;
            AddClientView.Visibility = Visibility.Visible;
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            AddClientBtn.Visibility = Visibility.Visible;
            ClientsDataGrid.Visibility = Visibility.Visible;
            DeleteClientBtn.Visibility = Visibility.Visible;
            SaveBtn.Visibility = Visibility.Visible;
            ReturnBtn.Visibility = Visibility.Collapsed;
            AddClientView.Visibility = Visibility.Collapsed;
        }

        private void ClientsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}