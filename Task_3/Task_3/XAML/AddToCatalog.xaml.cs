using System;
using System.Windows;
using System.Xml.Linq;
using Task_3.Class;

namespace Task_3.XAML
{
    public partial class AddToCatalog : Window
    {
        public AddToCatalog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string spath = @"C:\Users\Хозяйн\source\repos\Task_3\Task_3\XML\Catalog.xml";
            Product prod = new Product(namebox.Text, descbox.Text, typebox.Text, Convert.ToInt32(pricebox.Text));
            XDocument doc = XDocument.Load(spath);
            XElement root = new XElement("Employee");
            root.Add(new XAttribute("Name", prod.Name));
            root.Add(new XElement("Description", prod.Description));
            root.Add(new XElement("Type", prod.Type));
            root.Add(new XElement("Price", prod.Price));
            doc.Element("Employees").Add(root);
            doc.Save(spath);

        }
    }
}
