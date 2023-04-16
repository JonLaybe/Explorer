using Explorer.Model;
using Explorer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.ViewModel
{
    public class HomePageVM : ViewModelBase
    {
        private GetInfo _getInfo;
        private List<Disk> _listDisks;
        private Disk _selectedDisk;
        private NavigationPage _navigationPage;

        public HomePageVM()
        {
            _getInfo = new GetInfo();
            _listDisks = _getInfo.GetDisk();
            _navigationPage = NavigationPage.GetNavigationPage();
        }

        public List<Disk> ListDisk
        {
            get { return _listDisks; }
            set
            {
                _listDisks = value;
                Notify(nameof(ListDisk));
            }
        }

        public Disk SelectedDisk
        {
            get { return _selectedDisk; }
            set
            {
                _selectedDisk = value;
                Notify(nameof(SelectedDisk));
            }
        }

        public ButtonCommand OpenDiskBtn
        {
            get
            {
                return new ButtonCommand((object obj) =>
                {
                    _navigationPage.Parameter = SelectedDisk;
                    _navigationPage.ChangePage(new DirectoriesPageVM());
                });
            }
        }
    }
}
