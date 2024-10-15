using Atelier.Model;
using System.Data.Entity;
using System.Collections.ObjectModel;
using Atelier.Utilities;
using System.Windows;

namespace Atelier.ViewModel
{
    public class ModelsVM : ViewModelBase
    {
        private AtelierContext _atelierContext;

        private Model.Model _model = new Model.Model();

        private Model.Model _selectedModel = new Model.Model();

        public ObservableCollection<Model.Model> Models { get; set; }

        public ObservableCollection<Material> Materials { get; set; }

        public ObservableCollection<Model.Size> Sizes { get; set; }

        public ObservableCollection<Model.Color> Colors { get; set; }

        public Model.Model SelectedModel
        {
            get
            {
                return _selectedModel;
            }

            set
            {
                _selectedModel = value;
                OnPropertyChanged("ModelTitle");
            }
        }

        public string ModelTitle
        {
            get
            {
                return _model.model_title;
            }

            set
            {
                _model.model_title = value;
                OnPropertyChanged("ModelTitle");
            }
        }

        public int Color
        {
            get
            {
                return _model.color;
            }
            set
            {
                _model.color = value;
                OnPropertyChanged("Color");
            }
        }

        public int Size
        {
            get
            {
                return _model.size;
            }
            set
            {
                _model.size = value;
                OnPropertyChanged("Size");
            }
        }

        public int Material
        {
            get
            {
                return _model.material;
            }
            set
            {
                _model.material = value;
                OnPropertyChanged("Material");
            }
        }

        public RelayCommand _editCommand;

        private RelayCommand _addModel;

        private RelayCommand _deleteModel;

        public RelayCommand DeleteModel
        {
            get
            {
                return _deleteModel ?? (_deleteModel = new RelayCommand(obj =>
                {
                    if (_selectedModel != null)
                    {
                        Models.Remove(_selectedModel);
                        MessageBox.Show("Succesful");
                        _atelierContext.SaveChanges();
                    }
                }));
            }
        }

        public RelayCommand AddModel
        {
            get
            {
                return _addModel ?? (_addModel = new RelayCommand(obj =>
                {
                    if (_model.model_title != null && _model.model_title.Contains(" ") == false)
                    {
                        Models.Insert(Models.Count, _model);
                        MessageBox.Show("Succesful");
                        _atelierContext.SaveChanges();
                    }
                    else
                        MessageBox.Show("You must enter name of model");
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
                        if (_selectedModel != null)
                        {
                            _atelierContext.SaveChanges();
                        }
                    }));
            }
        }

        public ModelsVM()
        {
            _atelierContext = new AtelierContext();

            _atelierContext.Models.Load();
            Models = _atelierContext.Models.Local;

            _atelierContext.Materials.Load();
            Materials = _atelierContext.Materials.Local;

            _atelierContext.Colors.Load();
            Colors = _atelierContext.Colors.Local;
            
            _atelierContext.Sizes.Load();
            Sizes = _atelierContext.Sizes.Local;
        }
    }
}
