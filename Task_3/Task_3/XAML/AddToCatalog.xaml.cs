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
            XDocument xDoc = XDocument.Load(spath);
            XNode xNewNode = new XElement("Employee", new XAttribute("Name", prod.Name),
                new XElement("Description", prod.Description),
                new XElement("Type", prod.Type),
                new XElement("Price",prod.Price));
            xDoc.Root.Add(xNewNode);
            MessageBox.Show(xNewNode.ToString());
            xDoc.Save(spath);

        }
    }
}
