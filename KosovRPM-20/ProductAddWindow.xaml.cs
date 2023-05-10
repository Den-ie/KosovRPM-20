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
    /// Логика взаимодействия для ProductAddWindow.xaml
    /// </summary>
    public partial class ProductAddWindow : Window
    {
        public ProductAddWindow()
        {
            InitializeComponent();
        }

        FactoryEntities db = FactoryEntities.GetContext();
        ProductDirectory p1 = new ProductDirectory();

        private void Add(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (!Int32.TryParse(CostText.Text, out int x))
                errors.AppendLine("Введите стоимость сборки");
            if (NameText.Text == null)
                errors.AppendLine("Введите название");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            p1.ProductName = NameText.Text;
            p1.MakeCost = x;

            try
            {
                db.ProductDirectory.Add(p1);
                db.SaveChanges();
                MessageBox.Show("Сохранено");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите не повторяющуюся комбинацию имен");
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
