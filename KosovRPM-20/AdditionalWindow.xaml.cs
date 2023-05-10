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
    /// <summary>
    /// Логика взаимодействия для AdditionalWindow.xaml
    /// </summary>
    public partial class AdditionalWindow : Window
    {

        private FactoryEntities _db = FactoryEntities.GetContext();

        public AdditionalWindow()
        {
            InitializeComponent();

            _db.DetailDirectory.Load();
            _db.ProductCompound.Load();
            _db.ProductDirectory.Load();
            _db.ReleasePlan.Load();
            _db.Workshop.Load();

            DetailList.ItemsSource = _db.DetailDirectory.Local.ToBindingList();
            ProductList.ItemsSource = _db.ProductDirectory.Local.ToBindingList();
            ReleasePlanDB.ItemsSource = _db.ReleasePlan.Local.ToBindingList();
            Workshops.ItemsSource = _db.Workshop.Local.ToBindingList();
        }

        private void DeleteDetails(object sender, RoutedEventArgs e)
        {
            if (DetailList.SelectedItem == null) return;

            try
            {
                _db.DetailDirectory.Remove(DetailList.SelectedItem as DetailDirectory);
                _db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("не получилось удалить запись", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ProductDelete(object sender, RoutedEventArgs e)
        {
            if (ProductList.SelectedItem == null) return;

            try
            {
                _db.ProductDirectory.Remove(ProductList.SelectedItem as ProductDirectory);
                _db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("не получилось удалить запись", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeletePlanReaselese_Click(object sender, RoutedEventArgs e)
        {
            if (ReleasePlanDB.SelectedItem == null) return;

            try
            {
                _db.ReleasePlan.Remove(ReleasePlanDB.SelectedItem as ReleasePlan);
                _db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("не получилось удалить запись", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WorkDel(object sender, RoutedEventArgs e)
        {
            if (Workshops.SelectedItem == null) return;

            try
            {
                _db.Workshop.Remove(Workshops.SelectedItem as Workshop);
                _db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("не получилось удалить запись", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WorkAdd(object sender, RoutedEventArgs e)
        {
            AddWorkshopWindow AddWorkshopWindow = new AddWorkshopWindow();
            AddWorkshopWindow.ShowDialog();
        }

        private void AddDetail_Click(object sender, RoutedEventArgs e)
        {
            AddDetailWindow addDetailWindow= new AddDetailWindow();
            addDetailWindow.ShowDialog();
        }

        private void ProductAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductAddWindow productAddWindow= new ProductAddWindow();
            productAddWindow.ShowDialog();
        }

        private void PlanAddButton_Click(object sender, RoutedEventArgs e)
        {
            RelasePlanAddWindow RelasePlanAddWindow = new RelasePlanAddWindow();
            RelasePlanAddWindow.ShowDialog();
        }
    }
}
