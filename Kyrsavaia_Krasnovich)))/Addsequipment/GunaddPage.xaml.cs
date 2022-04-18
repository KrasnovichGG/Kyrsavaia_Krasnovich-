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
    /// Логика взаимодействия для GunaddPage.xaml
    /// </summary>
    public partial class GunaddPage : Window
    {
        public GunaddPage()
        {
            InitializeComponent();
        }

        private async void btnaddbdgun_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEmptyOrNull())
            {
                Gun guns = new Gun(txtbxaddgun.Text);
                guns.Tankist += Message;
                await guns.AddToDataBaseGun();
                txtbxaddgun.Clear();
            }
            
        }
        private void btnback2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Message(string a)
        {
            MessageBox.Show(a);
        }
        private bool CheckEmptyOrNull()
        {
            if (txtbxaddgun.Text != String.Empty)
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
