using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Task_3.Class;

namespace Task_3.XAML
{
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            regbut.IsEnabled = false;

        }
        public void PassIsEnabled()
        {
            bool name = Regex.IsMatch(namebox.Text, @"^[\p{L} \.\-]+$");
            bool email = Regex.IsMatch(emailbox.Text, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            bool pass = Regex.IsMatch(passbox.Password.ToString(), @"[0-9a-zA-Z!@#$%^&*]{6,}");
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
        private void Passbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PassIsEnabled();
        }
        public void Registr()
        {
            string path = @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3\Task_3\XML\Users.xml";
            XDocument xDoc = XDocument.Load(path);
            XNode xNewNode = new XElement("Employee", new XAttribute("Name", namebox.Text),
                new XElement("Email", emailbox.Text),
                new XElement("PassWord", passbox.Password.ToString()));
            xDoc.Root.Add(xNewNode);
            MessageBox.Show(xNewNode.ToString());
            xDoc.Save(path);
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
