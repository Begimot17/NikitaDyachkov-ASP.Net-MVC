using System.Collections.Generic;
using System.Windows;
using Task_3.Class;

namespace Task_3.XAML
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Regbut_Click(object sender, RoutedEventArgs e)
        {
            if (emailbox.Text == "nikita@gmail.com" && passbox.Password.ToString() == "123456")
            {
                Admin admin = new Admin();
                admin.Show();
                Close();
            }
            else
            {
                List<UserReg> users = new List<UserReg>();
                users = UserReg.UserList();
                foreach (UserReg x in users)
                {
                    if (x.pass == passbox.Password.ToString() && x.email == emailbox.Text)
                    {
                        string name = x.name;
                        User user = new User(name);
                        user.Show();
                        Close();
                        return;
                    }
                }
                MessageBox.Show("Неверный email или пароль");
            }
        }
    }
}
