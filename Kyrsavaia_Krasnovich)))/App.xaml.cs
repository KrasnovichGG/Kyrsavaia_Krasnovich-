using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kyrsavaia_Krasnovich___
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly string NameBase = "TanksVikipedia";
        public static readonly string ConnectionString = "mongodb://localhost";
        public static readonly string UserCollection = "Users";
        public static readonly string ArmorCollection = "Armors";
        public static Users Users  { get; set; }
        public static Armor Armors { get; set; }
    }
}
