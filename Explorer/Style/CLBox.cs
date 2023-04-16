using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Explorer.Style
{
    public class CLBox : Control
    {
        static CLBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CLBox), new FrameworkPropertyMetadata(typeof(CLBox)));
        }

        public string TextHeader
        {
            get { return (string)GetValue(TextHeaderProperty); }
            set { SetValue(TextHeaderProperty, value); }
        }
        public static readonly DependencyProperty TextHeaderProperty = DependencyProperty.Register("TextHeader", typeof(string), typeof(CLBox), new PropertyMetadata(null));

        public object Context
        {
            get { return (object)GetValue(ContextProperty); }
            set { SetValue(ContextProperty, value); }
        }
        public static readonly DependencyProperty ContextProperty = DependencyProperty.Register("Context", typeof(object), typeof(CLBox), new PropertyMetadata(null));
    }
}
