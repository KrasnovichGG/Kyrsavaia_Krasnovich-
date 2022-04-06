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
using System.Windows.Shapes;

namespace Kyrsavaia_Krasnovich___
{
    /// <summary>
    /// Логика взаимодействия для OsnovaMenuUser.xaml
    /// </summary>
    public partial class OsnovaMenuUser : Window
    {
        //public static Armor Armors { get; set; }
        //public static Engine Engines { get; set; }
        public OsnovaMenuUser()
        {
            InitializeComponent();
            if (App.Users.IsAdmin)
            {
                btntankadd.Visibility = Visibility.Visible;
                bntopenprovodnik.Visibility = Visibility.Visible;
                updatephoto.Visibility = Visibility.Visible;
            }
            else if(App.Users.IsAdmin == false)
            {
                btntankadd.Visibility= Visibility.Collapsed;
                bntopenprovodnik.Visibility= Visibility.Collapsed;
                updatephoto.Visibility= Visibility.Collapsed;
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btntankadd_Click(object sender, RoutedEventArgs e)
        {
            Page1 TankADPAGE =  new Page1();
            TankADPAGE.Show();
        }
    }
}
