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
using RhinoWPFIntorWorkshop.VeiwsModels;

namespace RhinoWPFIntorWorkshop.Veiws
{
    /// <summary>
    /// Panel.xaml の相互作用ロジック
    /// </summary>
    public partial class Panel
    {
        public Panel(uint documentSerialNumber)
        {
            DataContext = new MyViewModel(documentSerialNumber);
            InitializeComponent();
        }

        private MyViewModel viewModel => DataContext as MyViewModel;

        private void Button_Click_Circle(object sender, RoutedEventArgs e)
        {
            Rhino.RhinoApp.RunScript("_circle 0,0,0 " + MySlider.Value.ToString(), false);
            MessageBox.Show("Circle created!");
        }
    }
}
