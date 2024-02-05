using KR2_Amirhanov.Models;
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

namespace KR2_Amirhanov.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        Employees contextEmployee;

        public RegisterPage()
        {
            InitializeComponent();
            CBRoles.ItemsSource = App.DB.Roles.ToList();
            CBDepartaments.ItemsSource = App.DB.Departments.ToList();
            contextEmployee = new Employees();
            DataContext = contextEmployee;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            App.DB.Employees.Add(contextEmployee);
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
