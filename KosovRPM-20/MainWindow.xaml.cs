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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KosovRPM_20
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FactoryEntities db = FactoryEntities.GetContext();

        public MainWindow()
        {
            InitializeComponent();
            this.Height += 25;

            db.ProductCompound.Load();
            db.DetailDirectory.Load();
            db.ProductDirectory.Load();
            db.ReleasePlan.Load();
            db.Workshop.Load();

            DB.ItemsSource = db.ProductCompound.Local.ToBindingList();
        }


        private void AddButton(object sender, RoutedEventArgs e)
        {
            AddRecord f = new AddRecord();
            f.ShowDialog();
            DB.Focus();
            _productcompound = db.ProductCompound.ToList();
            DB.ItemsSource = _productcompound;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            int indexRow = DB.SelectedIndex;
            if (indexRow != -1)
            {
                ProductCompound row = (ProductCompound)DB.Items[indexRow];
                Data.Id = row.ProductCode;
                EditRecord f = new EditRecord(DB.SelectedItem as ProductCompound);
                f.ShowDialog();
                DB.Items.Refresh();
                DB.Focus();
                _productcompound = db.ProductCompound.ToList();
                DB.ItemsSource = _productcompound;
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить выбранную запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    ProductCompound row = (ProductCompound)DB.SelectedItems[0];
                    db.ProductCompound.Remove(row);
                    db.SaveChanges();
                    _productcompound = db.ProductCompound.ToList();
                    DB.ItemsSource = _productcompound;
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выбирите запись");
                }
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Косов Даниил ИСП-34 \nВариант №4");
        }

        List<ProductCompound> _productcompound;

        private void CancelFiltered(object sender, RoutedEventArgs e)
        {
            _productcompound = db.ProductCompound.ToList();
            DB.ItemsSource = _productcompound;
        }

        private void Aditins(object sender, RoutedEventArgs e)
        {
            AdditionalWindow directoryWindow = new AdditionalWindow();
            directoryWindow.ShowDialog();
        }
    }
}   
