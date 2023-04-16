using Explorer.Model;
using Explorer.Model.Directories;
using Explorer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Explorer.ViewModel
{
    public class MainWindowVM : ViewModelBase, INavigationPage
    {
        private NavigationPage _navigationPage;
        private GetInfo _getInfo;
        private List<Disk> _listDisk; // список дисков
        private Disk _selectedDisk; // выбранный диск
        private object _currentView; // выбранный view
        private string _path;

        public MainWindowVM()
        {
            _navigationPage = NavigationPage.GetNavigationPage();
            _navigationPage.MainViewModel = this;

            _getInfo = new GetInfo();
            ListDisks = _getInfo.GetDisk();
            NotifyDirectorie.ViewModel = this;

            ChangePage(new HomePageVM());
        }

        public void ChangePage(ViewModelBase viewModel)
        {
            CurrentView = viewModel;
        }

        public void ChangedDirectorie(string path)
        {
            throw new NotImplementedException();
        }

        public List<Disk> ListDisks
        {
            get { return _listDisk; }
            set
            {
                _listDisk = value;
                Notify(nameof(ListDisks));
            }
        }

        public Disk SelectedDisk
        {
            get { return _selectedDisk; }
            set
            {
                _selectedDisk = value;
                Notify(nameof(SelectedDisk));
                _navigationPage.Parameter = _selectedDisk;
                ChangePage(new DirectoriesPageVM());
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                Notify(nameof(Path));
            }
        }

        public object CurrentView // выбранный view
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                Notify(nameof(CurrentView));
            }
        }

        public ButtonCommand HomePageBtn
        {
            get
            {
                return new ButtonCommand((object obj) =>
                {
                    ChangePage(new HomePageVM());
                });
            }
        }
    }
}
