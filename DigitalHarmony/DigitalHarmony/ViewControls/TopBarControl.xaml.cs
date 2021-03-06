using DigitalHarmony.ViewWindows;
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

namespace DigitalHarmony.ViewControls
{
    /// <summary>
    /// Interaction logic for TopBarControl.xaml
    /// </summary>
    public partial class TopBarControl : UserControl
    {
        public TopBarControl()
        {
            InitializeComponent();
        }

        private void settingsBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = SettingsWindow.Instance;
            settingsWindow.Show();
        }
    }
}
