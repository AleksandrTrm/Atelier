using System;
using Atelier.Model;
using System.Data.Entity;
using System.Collections.ObjectModel;
using Atelier.Utilities;
using System.Windows;

namespace Atelier.ViewModel
{
    public class OrdersVM : ViewModelBase
    {
        public AtelierContext _atelierContext;

        public ObservableCollection<Order> Orders { get; set; }

        private Order _order = new Order();

        private Order _selectedOrder = new Order(); 

        public Order Order
        {
            get
            {
                return _order;
            }

            set
            {
                _order = value;
                OnPropertyChanged("Order");
            }
        }

        public Order SelecteOrder
        {
            get
            {
                return _selectedOrder;
            }

            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        public DateTime OrderDate
        {
            get
            {
                return _order.date_of_order;
            }

            set
            {
                _order.date_of_order = value;
                OnPropertyChanged("OrderDate");
            }
        }

        public float TotalCost
        {
            get
            {
                return _order.total_cost;
            }

            set
            {
                _order.total_cost = value;
                OnPropertyChanged("TotalCost");
            }
        }

        public int Model
        {
            get
            {
                return _order.model;
            }

            set
            {
                _order.model = value;
                OnPropertyChanged("Model");
            }
        }

        public int Client
        {
            get
            {
                return _order.client;
            }

            set
            {
                _order.client = value;
                OnPropertyChanged("Client");
            }
        }

        private RelayCommand _addCommand;

        public RelayCommand AddOrder
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        if (_order != null)
                        {
                            if (_order.date_of_order != null && _order.total_cost > 0 && _order.total_cost < int.MaxValue)
                            {
                                Orders.Insert(Orders.Count, _order);
                                MessageBox.Show("Succesful");
                                _atelierContext.SaveChanges();
                            }
                            else { MessageBox.Show("Something wasn't entered"); }
                        }
                    }));
            }
        }

        private RelayCommand _deleteCommannd;

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommannd ??
                    (_deleteCommannd = new RelayCommand(obj =>
                    {
                        if (_order != null)
                        {
                            Orders.Remove(_order);
                            _atelierContext.SaveChanges();
                        }
                    }));
            }
        }

        private RelayCommand _editCommand;

        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ??
                    (_editCommand = new RelayCommand(obj =>
                    {
                        if (_order != null)
                            _atelierContext.SaveChanges();

                    }));
            }
        }

        public OrdersVM()
        {
            _atelierContext = new AtelierContext();

            _atelierContext.Orders.Load();
            Orders = _atelierContext.Orders.Local;
        }
    }
}
