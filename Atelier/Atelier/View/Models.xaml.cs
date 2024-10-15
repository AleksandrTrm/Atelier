using Atelier.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Atelier.View
{
	public partial class Models : UserControl
	{
		public Models()
		{
			InitializeComponent();						
		}

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateBtn.Visibility = Visibility.Visible;
            ModelsDataGrid.Visibility = Visibility.Visible;
            CreateModelView.Visibility = Visibility.Collapsed;
            ReturnBtn.Visibility = Visibility.Collapsed;
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateBtn.Visibility = Visibility.Collapsed;
            ModelsDataGrid.Visibility = Visibility.Collapsed;
            CreateModelView.Visibility = Visibility.Visible;
            ReturnBtn.Visibility = Visibility.Visible;
        }
    }
}