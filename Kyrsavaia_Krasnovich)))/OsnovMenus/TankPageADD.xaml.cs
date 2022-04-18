using Kyrsavaia_Krasnovich___.Addsequipment;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Window
    {
        public Page1()
        {
            InitializeComponent();
            GetArmorCmb();
        }

        private void GetArmorCmb()
        {
            foreach (var item in Armor.TakeArmorList().Result)
            {
                cmbboxarmor.Items.Add(item.NameArmor);
            }
            
            foreach (var item in Engine.TakeEngineList().Result)
            {
                cmbboxengine.Items.Add(item.Name);
            }
            
            foreach (var item in Gun.TakeGunList().Result)
            {
                cmbboxgun.Items.Add(item.Name);
            }
        }

        private void btnaddarmorDB_Click(object sender, RoutedEventArgs e)
        {
            AddBron addBron = new AddBron();
            addBron.Show();
        }

        private void btnaddengineDB_Click(object sender, RoutedEventArgs e)
        {
            AddEnginePage addEnginePage = new AddEnginePage();
            addEnginePage.Show();
        }

        private async void bntaddtankinprolojenie_Click(object sender, RoutedEventArgs e)
        {
            Tank tank = new Tank(txtbxnametank.Text, txtspeedaddpage.Text, txtdlinakorpusapageadd.Text, 
                godvipuskaaddpage.Text, kalibraddpage.Text, await Armor.GetArmor(cmbboxarmor.Text), 
                await Engine.GetEngine(cmbboxengine.Text), await Gun.GetGun(cmbboxgun.Text));
            tank.Tankist += (e) => MessageBox.Show(e);
            await tank.AddToDataBaseTank();
        }

        private void btnaddGunDB_Click(object sender, RoutedEventArgs e)
        {
           GunaddPage gunaddPage = new GunaddPage();
           gunaddPage.Show();
        }

        private void cmbboxgun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
