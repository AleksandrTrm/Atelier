using Atelier.View;
using Atelier.Utilities;
using System.Windows.Input;

namespace Atelier.ViewModel
{
    public class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand ClientsCommand { get; set; }        
        public ICommand FittingsCommand { get; set; }        
        public ICommand ModelsCommand { get; set; }
        public ICommand OrdersCommand { get; set; }        

        private void Clients(object obj) => CurrentView = new ClientsVM();
        private void Fittings(object obj) => CurrentView = new FittingsVM();
        private void Orders(object obj) => CurrentView = new OrdersVM();
        private void Models(object obj) => CurrentView = new ModelsVM();

        public NavigationVM()
        {
            ClientsCommand = new RelayCommand(Clients);
            FittingsCommand = new RelayCommand(Fittings);
            OrdersCommand = new RelayCommand(Orders);
            ModelsCommand = new RelayCommand(Models);
            
            CurrentView = new Clients();
        }
    }
}
