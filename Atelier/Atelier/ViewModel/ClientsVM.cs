using Atelier.Model;
using System.Data.Entity;
using System.Collections.ObjectModel;
using Atelier.Utilities;
using System.Windows;

namespace Atelier.ViewModel
{
    /// <summary>
    /// Description of ClientsVM.
    /// </summary>
    public class ClientsVM : ViewModelBase
    {
        private AtelierContext _atelierContext;

        private Client _client = new Client();

        public ObservableCollection<Client> Clients { get; set; }

        private Client _selectedClient = new Client();

        public Client SelectedClient
        {
            get { return _selectedClient; }

            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        public string ClientName
        {
            get
            {
                return _client.client_name;
            }
            set
            {
                _client.client_name = value;
                OnPropertyChanged("ClientName");
            }
        }

        public string ClientSurname
        {
            get
            {
                return _client.client_surname;
            }
            set
            {
                _client.client_surname = value;
                OnPropertyChanged("ClientSurname");
            }
        }

        public string ClientPhone
        {
            get
            {
                return _client.client_phone;
            }
            set
            {
                _client.client_phone = value;
                OnPropertyChanged("ClientPhone");
            }
        }

        private RelayCommand _addCommand;

        private RelayCommand _deleteCommand;

        private RelayCommand _editCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        bool validData = false;

                        if (_client.client_name != null && _client.client_surname != null && _client.client_phone != null)
                        {
                            if (_client.client_name.Contains(" ") == false && _client.client_name.Length > 0 && _client.client_name.Length < 51)
                            {
                                if (_client.client_surname.Contains(" ") == false && _client.client_surname.Length > 0 && _client.client_surname.Length < 101)
                                {
                                    if (_client.client_phone.Contains(" ") == false && _client.client_phone.Length == 11)
                                        validData = true;
                                    else
                                        MessageBox.Show("Phone does not meet conditions");
                                }
                                else
                                    MessageBox.Show("Surname does not meet conditions");
                            }
                            else
                                MessageBox.Show("Name does not meet conditions");
                        }
                        else
                            MessageBox.Show("Something wasn't entered");                        


                        if (validData)
                        {
                            Clients.Insert(Clients.Count, _client);
                            MessageBox.Show("Succesful");
                            _atelierContext.SaveChanges();
                        }
                    }));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                    (_deleteCommand = new RelayCommand(obj => {
                        if (_selectedClient != null)
                        {
                            Clients.Remove(_selectedClient);
                            MessageBox.Show("Succesful");
                            _atelierContext.SaveChanges();
                        }
                    }));

            }
        }

        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ??
                    (_editCommand = new RelayCommand(obj =>
                    {
                        if (_selectedClient != null)
                        {
                            _atelierContext.SaveChanges();
                        }

                    }));
            }
        }

        public ClientsVM()
        {
            _atelierContext = new AtelierContext();

            _atelierContext.Clients.Load();
            Clients = _atelierContext.Clients.Local;
        }
    }
}
