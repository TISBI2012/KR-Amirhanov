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
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        private Employees newEmployee;
        public AddEmployeePage()
        {
            InitializeComponent();
            newEmployee = new Employees { RoleID = 1, DepartmentID = App.loggedEmployye.DepartmentID };
            DataContext = newEmployee;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (newEmployee.DepartmentID == null)
            {
                MessageBox.Show("Отсутствует информация об отделе текущего пользователя. Невозможно добавить программиста.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            App.DB.Employees.Add(newEmployee);
            App.DB.SaveChanges();
            MessageBox.Show("Программист успешно добавлен");
        }
    }
}
