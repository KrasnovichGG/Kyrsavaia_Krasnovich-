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
    /// Логика взаимодействия для AddBron.xaml
    /// </summary>
    public partial class AddBron : Window
    {
        public AddBron()
        {
            InitializeComponent();
        }

        private void btnback3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnaddarmor_Click(object sender, RoutedEventArgs e)
        {
            if (!await Check())
            {
                Armor armors = new Armor(txtbxaddarmor.Text);
                armors.AddToDataBaseArmor();
                MessageBox.Show("Успешное добавление Бронеплит");
                txtbxaddarmor.Clear();
            }
            else
            {
                MessageBox.Show("Такая Бронеплита уже существует");

            }
        }
        private async Task<bool> Check()
        {
            var ArmorCollection = await Armor.TakeArmorList();
            foreach (var item in ArmorCollection)
            {
                if (txtbxaddarmor.Text == item.NameArmor)
                    return true;

            }
            return false;
        }


    }
}

