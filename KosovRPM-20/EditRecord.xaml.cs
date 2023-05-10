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
    /// Логика взаимодействия для EditRecord.xaml
    /// </summary>
    public partial class EditRecord : Window
    {
        public EditRecord()
        {
            InitializeComponent();
            this.Height += 25;
        }

        FactoryEntities db = FactoryEntities.GetContext();
        ProductCompound p1 = new ProductCompound();


        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            p1 = db.ProductCompound.Find(Data.Id);
            DetailsCountEdit.Text = p1.DetailCount.ToString();
        }

        private void Add(object sender, RoutedEventArgs e)

        {
            StringBuilder errors = new StringBuilder();

            if (!Int32.TryParse(DetailsCountEdit.Text, out int x))
                errors.AppendLine("Введите кол-во деталей");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            p1.DetailCount = x;

            try
            {
                db.SaveChanges();
                MessageBox.Show("Сохранено");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}
