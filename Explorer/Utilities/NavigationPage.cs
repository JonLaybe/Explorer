using Explorer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Utilities
{
    public class NavigationPage
    {
        public object Parameter { get; set; }
        public MainWindowVM MainViewModel { get; set; }
        private static NavigationPage _navigationPage;

        private NavigationPage() { }

        public void ChangePage(ViewModelBase viewModel)
        {
            MainViewModel.ChangePage(viewModel);
        }

        public static NavigationPage GetNavigationPage() =>
            _navigationPage == null ? _navigationPage = new NavigationPage() : _navigationPage;
    }
}
