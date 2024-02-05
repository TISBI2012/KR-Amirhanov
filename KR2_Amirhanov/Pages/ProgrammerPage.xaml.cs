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
    /// Логика взаимодействия для ProgrammerPage.xaml
    /// </summary>
    public partial class ProgrammerPage : Page
    {
        public ProgrammerPage()
        {
            InitializeComponent();
            LoadProgrammers();
        }

        private void LoadProgrammers()
        {
            var programmersWithTasks = App.DB.Employees
                           .Where(e => e.RoleID == 1 && e.DepartmentID == App.loggedEmployye.DepartmentID)
                           .Select(e => new
                           {
                               EmployeeID = e.EmployeeID,
                               Name = e.FullName,
                               TaskName = e.Tasks.Select(t => t.Title).FirstOrDefault()
                           })
                           .ToList();
            ProgrammersDataGrid.ItemsSource = programmersWithTasks;
        }
    }
}
