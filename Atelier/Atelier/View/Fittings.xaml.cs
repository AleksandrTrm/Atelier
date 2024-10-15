using System.Windows;
using System.Windows.Controls;

namespace Atelier.View
{
    /// <summary>
    /// Interaction logic for Fittings.xaml
    /// </summary>
    public partial class Fittings : UserControl
    {
        public Fittings()
        {
            InitializeComponent();
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            AddFittingBtn.Visibility = Visibility.Visible;
            FittingsDataGrid.Visibility = Visibility.Visible;
            RemoveFittingBtn.Visibility = Visibility.Visible;
            ReturnBtn.Visibility = Visibility.Collapsed;
            AddClientView.Visibility = Visibility.Collapsed;
        }

        private void AddFittingBtn_Click(object sender, RoutedEventArgs e)
        {
            ReturnBtn.Visibility = Visibility.Visible;
            RemoveFittingBtn.Visibility = Visibility.Collapsed;
            AddFittingBtn.Visibility = Visibility.Collapsed;
            FittingsDataGrid.Visibility = Visibility.Collapsed;
            AddClientView.Visibility = Visibility.Visible;
        }
    }
}