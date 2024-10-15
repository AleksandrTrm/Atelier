using System;
using Atelier.Model;
using System.Data.Entity;
using System.Collections.ObjectModel;
using Atelier.Utilities;
using System.Windows;
using System.Windows.Markup;

namespace Atelier.ViewModel
{
    /// <summary>
    /// Description of FittingsVM.
    /// </summary>
    public class FittingsVM : ViewModelBase
    {
        private AtelierContext _atelierContext;

        public ObservableCollection<Fitting> Fittings { get; set; }

        private Fitting _selectedFitting = new Fitting();

        private Fitting _fitting = new Fitting();

        public Fitting Fitting
        {
            get { return _fitting; }
            set 
            {
                _fitting = value;
                OnPropertyChanged("Fitting");
            }
        }

        public Fitting SelectedFitting
        {
            get
            {
                return _selectedFitting;
            }

            set
            {
                _selectedFitting = value;
                OnPropertyChanged("SelectedFitting");
            }
        }

        public DateTime FittingDate
        {
            get
            {
                return _fitting.fitting_date;
            }
            set
            {
                _fitting.fitting_date = value;
                OnPropertyChanged("FittingDate");
            }
        }

        public int OrderNumber
        {
            get
            {
                return _fitting.order_id;
            }

            set
            {
                _fitting.order_id = value;
                OnPropertyChanged("OrderNumber");
            }
        }        

        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                    (_saveCommand = new RelayCommand(obj =>
                    {
                        if (_selectedFitting != null)
                        {
                            _atelierContext.SaveChanges();
                        }
                    }));
            }
        }

        private RelayCommand _removeCommand;

        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ??
                    (_removeCommand = new RelayCommand(obj =>
                    {
                        if (_selectedFitting != null)
                        {
                            Fittings.Remove(_selectedFitting);
                            MessageBox.Show("Succesful");
                            _atelierContext.SaveChanges();
                        }
                    }));
            }
        }

        private RelayCommand _addCommand;

        public RelayCommand AddCommnad
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        bool validData = false;


                        if (_fitting.fitting_date != null)
                        {
                            validData = true;
                        }
                        else
                            MessageBox.Show("Something wasn't entered");


                        if (validData)
                        {
                            Fittings.Insert(Fittings.Count, _fitting);
                            MessageBox.Show("Succeful");
                            _atelierContext.SaveChanges();
                        }

                    }));
            }
        }
        

        public FittingsVM()
        {
            _atelierContext = new AtelierContext();

            _atelierContext.Fittings.Load();
            Fittings = _atelierContext.Fittings.Local;
        }
    }
}
