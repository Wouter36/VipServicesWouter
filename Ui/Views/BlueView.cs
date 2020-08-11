using DataLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ui.ViewModels;

namespace Ui.Views
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        private ObservableCollection<Klant> klanten;
        private IEnumerable<Reservatie> reservaties;
        public UserControl2()
        {
            InitializeComponent();
            klanten = new ObservableCollection<Klant>(UnitOfWork.GetUnitOfWork().Klanten.FindAll());
            comboBoxKlanten.ItemsSource = klanten;
        }

        private void BtnToonReservatie_Click(object sender, RoutedEventArgs e)
        {
            //Klant klant = (Klant)this.comboBoxKlanten.SelectedItem;
            //List<Reservatie> reservaties = new List<Reservatie>();
            
            reservaties = UnitOfWork.GetUnitOfWork().Reservaties.FindAll(14);
            this.contentControl.Content = new UserControl3(reservaties);
        }
    }
}
