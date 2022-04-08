using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Armor armors = new Armor(txtbxaddarmor.Text);
            armors.Tankist += Message;
            await armors.AddToDataBaseArmor();
            txtbxaddarmor.Clear();
        }
        private void Message(string a)
        {
            MessageBox.Show(a);
        }
    }
}

