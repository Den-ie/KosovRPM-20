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
    /// Логика взаимодействия для AddWorkshopWindow.xaml
    /// </summary>
    public partial class AddWorkshopWindow : Window
    {
        public AddWorkshopWindow()
        {
            InitializeComponent();
        }

        FactoryEntities db = FactoryEntities.GetContext();
        Workshop p1 = new Workshop();

        private void Add(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (NameText.Text == null)
                errors.AppendLine("Введите стоимость");
            if (BossText.Text == null)
                errors.AppendLine("Введите название");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            p1.WorkshopName = NameText.Text;
            p1.Boss = BossText.Text;

            try
            {
                db.Workshop.Add(p1);
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
