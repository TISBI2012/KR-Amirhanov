using KR2_Amirhanov.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KR2_Amirhanov
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DemoExamsEntities DB = new DemoExamsEntities();
        public static Employees loggedEmployye = new Employees();
    }
}
