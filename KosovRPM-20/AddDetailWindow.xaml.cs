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
    /// Логика взаимодействия для AddDetailWindow.xaml
    /// </summary>
    public partial class AddDetailWindow : Window
    {
        public AddDetailWindow()
        {
            InitializeComponent();
        }

        FactoryEntities db = FactoryEntities.GetContext();
        DetailDirectory p1 = new DetailDirectory();

        private void Add(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (!Int32.TryParse(CostText.Text, out int x))
                errors.AppendLine("Введите стоимость");
            if (NameText.Text == null)
                errors.AppendLine("Введите название");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            p1.DetailName = NameText.Text;
            p1.Cost = x;

            try
            {
                db.DetailDirectory.Add(p1);
                db.SaveChanges();
                MessageBox.Show("Сохранено");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
