using DataLayer;
using DomainLayer;
using DomainLayer.Models;
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
            Klant klant = (Klant)this.comboBoxKlanten.SelectedItem;
            DateTime date = StartMomentPicker.SelectedDate.GetValueOrDefault();

            if (klant != null && !StartMomentPicker.SelectedDate.HasValue)
            {
                reservaties = UnitOfWork.GetUnitOfWork().Reservaties.FindAll(klant.Id);
            }
            else if(klant == null && StartMomentPicker.SelectedDate.HasValue)
            {
                reservaties = UnitOfWork.GetUnitOfWork().Reservaties.FindAll(date);
            }
            else if (klant != null && StartMomentPicker.SelectedDate.HasValue)
            {
                reservaties = UnitOfWork.GetUnitOfWork().Reservaties.FindAll(klant.Id, date);
            }
            
            if(reservaties.ToList().Count > 0)
            {
                comboBoxReservaties.ItemsSource = new ObservableCollection<Reservatie>(reservaties);
                if(comboBoxReservaties.SelectedIndex == -1)
                {
                    comboBoxReservaties.SelectedIndex = 0;
                }
                ReservatieUtils reservatieManager = new ReservatieUtils(UnitOfWork.GetUnitOfWork());
                reserveringdatalabel.Content = reservatieManager.GetReservatieInfo((Reservatie)comboBoxReservaties.SelectedItem);
            }
        }
    }
}
