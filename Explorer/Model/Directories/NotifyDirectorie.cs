using Explorer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Model.Directories
{
    public static class NotifyDirectorie
    {
        public static MainWindowVM ViewModel;

        public static void ChangedDirectorie(string path)
        {
            ViewModel.Path = path;
        }
    }
}
