using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DemoWPF.Controls
{
    public class MyCustomControl : ContentControl
    {

        #region MyCustomProperty

        public static readonly DependencyProperty MyCustomPropertyProperty = DependencyProperty.Register("MyCustomProperty", typeof(string), typeof(MyCustomControl), null);
        public string MyCustomProperty
        {
            get { return (string)GetValue(MyCustomPropertyProperty); }
            set { SetValue(MyCustomPropertyProperty, value); }
        }

        #endregion


    }
}
