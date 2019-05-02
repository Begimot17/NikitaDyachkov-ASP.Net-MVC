using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;
using Task_3.Class;

namespace Task_3.XAML
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
        }
        public User(string name)
        {
            InitializeComponent();
            lab.Content = $"Hello {name}";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = Product.ProdList();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List <Product>prod = Product.ProdList();
            

            foreach(Product x in prod)
            {
                if (x.Name == namebox.Text)
                {
                    
                        string spath = @"C:\Users\Хозяйн\source\repos\Task_3\Task_3\XML\Cart.xml";
                        XDocument doc = XDocument.Load(spath);
                        XElement root = new XElement("Employee");
                        root.Add(new XAttribute("Name", x.Name));
                        root.Add(new XElement("Description", x.Description));
                        root.Add(new XElement("Type", x.Type));
                        root.Add(new XElement("Price", x.Price));
                        doc.Element("Employees").Add(root);
                        doc.Save(spath);
                    
                }
            }
        }
    }
}
