using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для AdminTasksPage.xaml
    /// </summary>
    public partial class AdminTasksPage : Page
    {
        public AdminTasksPage()
        {
            InitializeComponent(); 
            LoadTasks();
        }

        private void LoadTasks()
        {
            var tasksWithDetails = App.DB.Tasks
                .Where(t => t.DepartmentID == App.loggedEmployye.DepartmentID)
                .Include(t => t.TaskPriorities)
                .Include(t => t.TaskCategories)
                .Include(t => t.Orders)
                .ToList()
                .Select(t => new
                {
                    t.TaskID,
                    t.Title,
                    EmployeeName = App.DB.Employees.FirstOrDefault(e => e.EmployeeID == t.AssignedToEmployeeID)?.FullName,
                    PriorityName = t.TaskPriorities?.PriorityName,
                    CategoryName = t.TaskCategories?.CategoryName,
                    OrderDescription = t.Orders?.Description
                })
                .ToList();

            TasksDataGrid.ItemsSource = tasksWithDetails;
        }
    }
}
