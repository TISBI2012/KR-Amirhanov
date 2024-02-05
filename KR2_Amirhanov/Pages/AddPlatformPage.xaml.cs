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
    /// Логика взаимодействия для AddPlatformPage.xaml
    /// </summary>
    public partial class AddPlatformPage : Page
    {
        public Platforms Platform { get; set; } = new Platforms();

        public AddPlatformPage()
        {
            InitializeComponent();
            this.DataContext = this;
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            DepartmentBox.ItemsSource = App.DB.Departments.ToList();
            DepartmentBox.DisplayMemberPath = "Name";
            DepartmentBox.SelectedValuePath = "DepartmentID";
        }

        private void AddPlatform_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Platform.Name) || Platform.DepartmentID == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            App.DB.Platforms.Add(Platform);
            try
            {
                App.DB.SaveChanges();
                MessageBox.Show("Платформа успешно добавлена");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }
    }
}
