using DataLayer;
using DataLayer.Repositories;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private ObservableCollection<Limosine> limosines;
        private ObservableCollection<Klant> klanten;

        public UserControl1()
        {
            InitializeComponent();

            int[] uren = new int[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23 };
            UurComboBox.ItemsSource = uren;
            
            limosines = new ObservableCollection<Limosine>(UnitOfWork.GetUnitOfWork().Limosines.FindAll());
            klanten = new ObservableCollection<Klant>(UnitOfWork.GetUnitOfWork().Klanten.FindAll());
            comboBoxReservatie.ItemsSource = (ReservatieType[]) Enum.GetValues(typeof(ReservatieType));
            comboBoxLimosines.ItemsSource = limosines;
            comboBoxKlanten.ItemsSource = klanten;
        }

        private void BtnBevestigReservatie_Click(object sender, RoutedEventArgs e)
        {
            // Initialize
            ReservatieType type = (ReservatieType)comboBoxReservatie.SelectedItem;
            DateTime startMoment = DateTime.Parse(StartMomentPicker.ToString());
            startMoment = startMoment.AddHours((int)UurComboBox.SelectedItem);
            int uren = (int)DuurComboBox.SelectedItem;
            Klant klant = (Klant)comboBoxKlanten.SelectedItem;
            string vertrekLocatie = VertrekPlaatsComboBox.SelectedIndex.ToString();
            string aankomstLocatie = AankomstPlaatsComboBox.SelectedIndex.ToString();
            Limosine limosine = (Limosine)comboBoxLimosines.SelectedItem;
            IEnumerable<Reservatie> jaarReservaties = UnitOfWork.GetUnitOfWork().Reservaties.FindAll(klant.Id);
            jaarReservaties = jaarReservaties.Where(r => r.Startmoment.Year == startMoment.Year);
            int amtOfYearReservations = jaarReservaties.ToList().Count;

            // Apply
            Reservatie reservatie = new Reservatie(klant, aankomstLocatie, vertrekLocatie, startMoment, uren, limosine, type, null, 0, amtOfYearReservations); // Todo remove null
            UnitOfWork.GetUnitOfWork().Reservaties.AddReservatie(reservatie);
            UnitOfWork.GetUnitOfWork().Complete();

            // Notify user
            Window popup = new Window();
            popup.Content = "Reservatie aangemaakt";
            popup.Width = 150;
            popup.Height = 100;
            popup.ShowDialog();
        }
    }
}
