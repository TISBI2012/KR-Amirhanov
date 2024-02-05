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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Departments_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepartmentsPage());
        }

        private void MyTasks_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyTasksPage());
        }

        private void GetAdmin_Click(object sender, RoutedEventArgs e)
        {
            GetSystemAdministrator();
        }

        private void GetSystemAdministrator()
        {
            var systemAdministrators = App.DB.Employees
                                .Where(e => e.RoleID == 4) 
                                .Select(e => new
                                {
                                    EmployeeID = e.EmployeeID,
                                    Name = e.FullName,
                                })
                                .ToList();

            if (systemAdministrators.Count == 0) 
            {
                MessageBox.Show("Системный администратор не найден.");
            }
            else
            {
                MessageBox.Show("Системный администратор найден: " + systemAdministrators.First().Name);
            }
        }

    }
}
