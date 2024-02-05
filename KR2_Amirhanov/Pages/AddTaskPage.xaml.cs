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
    /// Логика взаимодействия для AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : Page
    {
        public Tasks Task { get; set; } = new Tasks();

        public AddTaskPage()
        {
            InitializeComponent();
            this.Task.Status = "waiting";
            this.Task.DepartmentID = App.loggedEmployye.DepartmentID;
            this.DataContext = this;

            LoadEmployees();
            LoadPriorities();
            LoadCategories();
            LoadOrders();
        }

        private void LoadOrders()
        {
            OrderBox.ItemsSource = App.DB.Orders.ToList();
            OrderBox.DisplayMemberPath = "Description";
            OrderBox.SelectedValuePath = "OrderID";
        }

        private void LoadEmployees()
        {
            var departmentId = App.loggedEmployye.DepartmentID;
            EmployeeBox.ItemsSource = App.DB.Employees.Where(e => e.RoleID == 1 && e.DepartmentID == departmentId).ToList();
            EmployeeBox.DisplayMemberPath = "Name";
            EmployeeBox.SelectedValuePath = "EmployeeID";
        }

        private void LoadPriorities()
        {
            PriorityBox.ItemsSource = App.DB.TaskPriorities.ToList();
            PriorityBox.DisplayMemberPath = "PriorityName";
            PriorityBox.SelectedValuePath = "PriorityID";
        }

        private void LoadCategories()
        {
            CategoryBox.ItemsSource = App.DB.TaskCategories.ToList();
            CategoryBox.DisplayMemberPath = "CategoryName";
            CategoryBox.SelectedValuePath = "CategoryID";
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Task.Title) || Task.AssignedToEmployeeID == null || Task.PriorityID == null || Task.CategoryID == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            
            App.DB.Tasks.Add(Task);
            App.DB.SaveChanges();
            MessageBox.Show("Задача успешно добавлена");
            NavigationService.Navigate(new AdminPage());
        }
    }
}
