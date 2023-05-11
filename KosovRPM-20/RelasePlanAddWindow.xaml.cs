using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для RelasePlanAddWindow.xaml
    /// </summary>
    public partial class RelasePlanAddWindow : Window
    {
        public RelasePlanAddWindow()
        {
            InitializeComponent();
            WorkshopCombo.ItemsSource = db.Workshop.ToList();
            WorkshopCombo.DisplayMemberPath = "WorkshopName";
        }

        FactoryEntities db = FactoryEntities.GetContext();
        ReleasePlan p1 = new ReleasePlan();

        private void Add(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (!Int32.TryParse(ProductCountText.Text, out int x))
                errors.AppendLine("Введите стоимость");
            if (WorkshopCombo.Text == null)
                errors.AppendLine("Выберите название цеха");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            p1.WorkshopCode = ((Workshop)WorkshopCombo.SelectedItem).WorkshopCode;
            p1.ProductCount = x;

            try
            {
                db.ReleasePlan.Add(p1);
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
