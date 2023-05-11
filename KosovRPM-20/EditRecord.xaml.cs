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

        public EditRecord(ProductCompound item)
        {
            InitializeComponent();
            ComboProduct.SelectedItem= item.ProductCode;
            ComboDetail.SelectedItem= item.DetailCode;
            ComboProduct.ItemsSource = db.ProductDirectory.ToList();
            ComboProduct.DisplayMemberPath = "ProductName";
            ComboDetail.ItemsSource = db.DetailDirectory.ToList();
            ComboDetail.DisplayMemberPath = "DetailName";
            DetailsCOUNT.Text = item.DetailCount.ToString();

            _record = item;

            this.Height += 25;
        }

        FactoryEntities db = FactoryEntities.GetContext();
        ProductCompound _record;



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

            _record.ProductDirectory = (ProductDirectory)ComboProduct.SelectedItem;
            _record.DetailDirectory = (DetailDirectory)ComboDetail.SelectedItem;
            _record.DetailCount = x;

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
