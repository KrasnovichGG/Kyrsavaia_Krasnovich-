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

namespace Kyrsavaia_Krasnovich___.Addsequipment
{
    /// <summary>
    /// Логика взаимодействия для AddEnginePage.xaml
    /// </summary>
    public partial class AddEnginePage : Window
    {
        Engine engine = new Engine("");
        public AddEnginePage()
        {
            InitializeComponent();
        }

        private void btnback4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnaddengine_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEmptyOrNull())
            {
                IEngine engines = new Engine(txtbxaddengine.Text);
                engines.Tankist += SetMessage;
                await engines.AddToDataBaseEngine();
                txtbxaddengine.Clear();
            }
        }

        private void SetMessage(string a)
        {
            MessageBox.Show(a);
        }
        private bool CheckEmptyOrNull()
        {
            if (txtbxaddengine.Text != String.Empty)
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
