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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void btnregistrationbd_Click(object sender, RoutedEventArgs e)
        {
            var ass = await Users.TakeList();
            if (!await CheckAvtorization() && CheckEmptyOrNull())
            {
                //txtboxnameuser.Text != String.Empty;
                Users users = new Users(txtboxnameuser.Text,txtboxgmail.Text, Passwordbxregistration.Password);
                users.AddToDataBase();
                MessageBox.Show("Успешное добавление!");
                txtboxgmail.Clear();
                txtboxnameuser.Clear();
                Passwordbxregistration.Clear();
            }
            else
            {
                MessageBox.Show("Такой пользователь уже существует!");
                
            }
        }
        private bool CheckEmptyOrNull()
        {
            if (txtboxnameuser.Text != String.Empty && txtboxgmail.Text != String.Empty && Passwordbxregistration.Password != String.Empty)
            {
                return true;
            }
            
            else
            {
                MessageBox.Show("Введие символы!!");
                return false;
            }
            
        }

        private async Task<bool> CheckAvtorization()
        {
            var CumCollection = await Users.TakeList();
            foreach (var item in CumCollection )
            {
                if (txtboxnameuser.Text == item.UserName)
                    return true;

            }
            return false;   
        }

        private void btnback1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
