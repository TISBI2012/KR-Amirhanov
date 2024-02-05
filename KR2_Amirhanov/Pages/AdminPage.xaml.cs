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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
           public AdminPage()
        {
            InitializeComponent();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(new AddEmployeePage());
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(new AddTaskPage());
        }

        private void ViewEmployees_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(new ProgrammerPage());
        }

        private void ViewTasks_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(new AdminTasksPage());
        }

        private void AddPlatform_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(new AddPlatformPage());
        }

        private void ViewPlatforms_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(new PlatformsPage());
        }

        private void ViewOrders_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(new OrdersPage());
        }
    }
}
