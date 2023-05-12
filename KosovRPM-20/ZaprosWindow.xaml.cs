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
using System.Windows.Shapes;

namespace KosovRPM_20
{
    /// <summary>
    /// Логика взаимодействия для ZaprosWindow.xaml
    /// </summary>
    public partial class ZaprosWindow : Window
    {
        public ZaprosWindow(List<ProductCompound> Zap)
        {
            InitializeComponent();
            ZaprosGrid.ItemsSource= Zap;    
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
