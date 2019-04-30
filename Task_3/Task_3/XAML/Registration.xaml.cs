using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        public void PassIsEnabled()
        {
            bool name = Regex.IsMatch(namebox.Text, @"^\w+");
            bool email = Regex.IsMatch(emailbox.Text, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            bool pass = Regex.IsMatch(passbox.Text, "^[0-9.,:!?]{1,8}$");
            if (name && email && pass)
            {
                regbut.IsEnabled = true;
            }
            else
                regbut.IsEnabled = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PassIsEnabled();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            PassIsEnabled();
        }

        private void Passbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PassIsEnabled();
        }
        public void Registr()
        {
            string spath = @"C:\Users\Хозяйн\source\repos\Task_3\Task_3\XML\Users.xml";
            UserReg user = new UserReg(namebox.Text, emailbox.Text, passbox.Text);
            XDocument doc = XDocument.Load(spath);
            XElement root = new XElement("Employee");
            root.Add(new XAttribute("Name", user.name));
            root.Add(new XElement("Email", user.email));
            root.Add(new XElement("PassWord", user.pass));
            doc.Element("Employees").Add(root);
            doc.Save(spath);
        }
        private void Regbut_Click(object sender, RoutedEventArgs e)
        {
            List<UserReg> users = new List<UserReg>();
            users = UserReg.UserList();
            bool proverka = true;
            foreach (UserReg x in users)
            {
                if (x.name == namebox.Text)
                {
                    MessageBox.Show("Пользователь с таким именем уже существует");
                    proverka = false;
                    break;
                }
                if (x.email == emailbox.Text)
                {
                    MessageBox.Show("Пользователь с таким email уже существует");
                    proverka = false;
                    break;
                }
            }
            if (proverka)
            {
                Registr();

                User user = new User(namebox.Text);
                user.Show();
                this.Close();
            }
        }
    }
}
