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
    /// Логика взаимодействия для MyTasksPage.xaml
    /// </summary>
    public partial class MyTasksPage : Page
    {
        public MyTasksPage()
        {
            InitializeComponent();
            LoadMyTasks();
        }

        private void LoadMyTasks()
        {
            var employeeId = App.loggedEmployye.EmployeeID;
            var myTasks = App.DB.Tasks
              .Where(t => t.AssignedToEmployeeID == employeeId)
              .Select(t => new
              {
                  TaskID = t.TaskID,
                  Title = t.Title,
                  PriorityName = t.TaskPriorities.PriorityName,
                  CategoryName = t.TaskCategories.CategoryName
              })
              .ToList();

            MyTasksDataGrid.ItemsSource = myTasks;
        }

        private void ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (button.IsEnabled) { 
                var task = button.DataContext as Tasks;
                if (task != null)
                {
                    task.Status = "success"; 
                    App.DB.SaveChanges(); 
                    LoadMyTasks(); 
                }
                }
            }
        }

    }
}
