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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KR2_Amirhanov;

namespace KR2_Amirhanov.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var username = LoginBox.Text;
            var password = Password.Password;

            var loggedUser = App.DB.Employees.FirstOrDefault(x => x.Login == username && x.Password == password);

            if (loggedUser == null)
            {
                MessageBox.Show("Попробуйте снова");

                return;
            }

            App.loggedEmployye = loggedUser;

            if (loggedUser.RoleID == 2)
            {
                NavigationService.Navigate(new AdminPage());
            }
            else
            {
                NavigationService.Navigate(new MainPage());
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }
    }
}
