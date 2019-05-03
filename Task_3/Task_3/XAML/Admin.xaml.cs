using System.Windows;
using Task_3.Class;

namespace Task_3.XAML
{
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = Product.ProdList();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AddToCatalog main = new AddToCatalog();
            main.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Remove main = new Remove();
            main.Show();
        }
    }
}
