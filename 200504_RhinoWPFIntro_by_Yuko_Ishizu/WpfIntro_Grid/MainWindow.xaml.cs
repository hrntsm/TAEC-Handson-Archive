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

namespace WpfIntro_Grid
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow:Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Line(object sender, RoutedEventArgs e)
        {
            string val = MySlider.Value.ToString();
            MessageBox.Show($"Line {val} Clicked!");
        }

        private void Button_Click_Circle(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Circle Clicked!");
        }

        private void Button_Click_Selector(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Selected Clicked!");
        }
    }
}
