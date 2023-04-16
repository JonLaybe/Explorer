using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Utilities
{
    public interface INavigationPage
    {
        void ChangePage(ViewModelBase viewModel);
    }
}
