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
    /// Логика взаимодействия для PlatformsPage.xaml
    /// </summary>
    public partial class PlatformsPage : Page
    {
        public PlatformsPage()
        {
            InitializeComponent();
            LoadPlatforms();
        }

        private void LoadPlatforms()
        {
            var platforms = App.DB.Platforms.ToList();
            PlatformsDataGrid.ItemsSource = platforms;
        }
    }
}
