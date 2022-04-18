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

namespace Kyrsavaia_Krasnovich___
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void VoitiinASS(object sender, RoutedEventArgs e)
        {
            if (await Check() && CheckEmptyOrNull())
            {
                OsnovaMenuUser osnovaMenuUser = new OsnovaMenuUser();
                osnovaMenuUser.Show();
                MessageBox.Show($"Успешный вход!{ (App.Users.IsAdmin ?"Админ":"Пользователь")}");
                this.Close();
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует!");
            }
        }
        private async Task<bool> Check()
        {
            var CumCollection = await Users.TakeList();
            foreach (var item in CumCollection)
            {
                if (txtboxlogin.Text == item.UserName && pasbx1.Password == item.Password)
                {
                    App.Users = item;
                    return true;
                }
                    

            }
            return false;
        }

        private void btnregistration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.Show();
        }

        private bool CheckEmptyOrNull()
        {
            if (txtboxlogin.Text != String.Empty && pasbx1.Password != String.Empty)
            {
                return true;
            }

            else
            {
                MessageBox.Show("Введие символы!!");
                return false;
            }

        }
    }
}
