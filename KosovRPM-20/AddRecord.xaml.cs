using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public partial class AddRecord : Window
    {
        public AddRecord()
        {
            InitializeComponent();
            this.Height += 25; 
            db.ProductCompound.Load();
            ComboDetail.ItemsSource = db.DetailDirectory.ToList();
            ComboDetail.DisplayMemberPath = "DetailName";
            ComboProduct.ItemsSource = db.ProductDirectory.ToList();
            ComboProduct.DisplayMemberPath = "ProductName";
        }

        FactoryEntities db = FactoryEntities.GetContext();
        ProductCompound p1 = new ProductCompound();

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (ComboDetail == null)
                errors.AppendLine("Укажите название детали");
            if (ComboProduct == null)
                errors.AppendLine("Укажите название изделия");
            if (!Int32.TryParse(DetailsCOUNT.Text, out int x))
                errors.AppendLine("Введите кол-во деталей");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            p1.ProductDirectory = (ProductDirectory)ComboProduct.SelectedItem;
            p1.DetailDirectory = (DetailDirectory)ComboDetail.SelectedItem;
            p1.DetailCount = x;

            try
            {
                db.ProductCompound.Add(p1);
                db.SaveChanges();
                MessageBox.Show("Сохранено");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите не повторяющуюся комбинацию имен");
            }
        }
    }
}
