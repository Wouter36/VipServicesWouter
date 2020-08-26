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

            // Add data as form options
            klanten = new ObservableCollection<Klant>(UnitOfWork.GetUnitOfWork().Klanten.FindAll());
            comboBoxReservatie.ItemsSource = (ReservatieType[]) Enum.GetValues(typeof(ReservatieType));
            comboBoxKlanten.ItemsSource = klanten;
        }

        /// <summary>
        ///  Adding options and removing incompatible ones
        /// </summary>
        private void OnTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((ReservatieType)comboBoxReservatie.SelectedItem == ReservatieType.Airport)
            {
                DuurComboBox.ItemsSource = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
                OverUrenComboBox.ItemsSource = new int[] { 0 };
                limosines = new ObservableCollection<Limosine>(UnitOfWork.GetUnitOfWork().Limosines.FindAll());
                comboBoxLimosines.ItemsSource = limosines;
                int[] uren = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
                UurComboBox.ItemsSource = uren;
            }
            else if((ReservatieType)comboBoxReservatie.SelectedItem == ReservatieType.Business)
            {
                DuurComboBox.ItemsSource = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
                OverUrenComboBox.ItemsSource = new int[] { 0 };
                limosines = new ObservableCollection<Limosine>(UnitOfWork.GetUnitOfWork().Limosines.FindAll());
                comboBoxLimosines.ItemsSource = limosines;
                int[] uren = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
                UurComboBox.ItemsSource = uren;
            }
            else if ((ReservatieType)comboBoxReservatie.SelectedItem == ReservatieType.Wellness)
            {
                DuurComboBox.ItemsSource = new int[] { 10 };
                OverUrenComboBox.ItemsSource = new int[] { 0 };
                limosines = new ObservableCollection<Limosine>(UnitOfWork.GetUnitOfWork().Limosines.FindAll()
                    .Where(l => l.WellnessPrijs != null));
                comboBoxLimosines.ItemsSource = limosines;
                UurComboBox.ItemsSource = new int[] { 7, 8, 9, 10, 11, 12 };
            }
            else if ((ReservatieType)comboBoxReservatie.SelectedItem == ReservatieType.Wedding)
            {
                DuurComboBox.ItemsSource = new int[] { 7 };
                OverUrenComboBox.ItemsSource = new int[] { 0,1,2,3,4};
                limosines = new ObservableCollection<Limosine>(UnitOfWork.GetUnitOfWork().Limosines.FindAll()
                    .Where(l => l.WeddingPrijs != null));
                comboBoxLimosines.ItemsSource = limosines;
                UurComboBox.ItemsSource = new int[] { 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            }
            else if ((ReservatieType)comboBoxReservatie.SelectedItem == ReservatieType.NightLife)
            {
                DuurComboBox.ItemsSource = new int[] { 7 };
                OverUrenComboBox.ItemsSource = new int[] { 0, 1, 2, 3, 4 };
                limosines = new ObservableCollection<Limosine>(UnitOfWork.GetUnitOfWork().Limosines.FindAll()
                    .Where(l => l.NightLifePrijs != null));
                comboBoxLimosines.ItemsSource = limosines;
                UurComboBox.ItemsSource = new int[] { 20, 21, 22, 23, 24 };
            }
        }

        private void BtnBevestigReservatie_Click(object sender, RoutedEventArgs e)
        {
            // Initialize
            ReservatieType type = (ReservatieType)comboBoxReservatie.SelectedItem;
            DateTime startMoment = DateTime.Parse(StartMomentPicker.ToString());
            startMoment = startMoment.AddHours((int)UurComboBox.SelectedItem);
            int uren = (int)DuurComboBox.SelectedItem;
            int overUren = (int)OverUrenComboBox.SelectedItem;
            Klant klant = (Klant)comboBoxKlanten.SelectedItem;
            string vertrekLocatie = VertrekPlaatsComboBox.Text;
            string aankomstLocatie = AankomstPlaatsComboBox.Text;
            Limosine limosine = (Limosine)comboBoxLimosines.SelectedItem;
            IEnumerable<Reservatie> jaarReservaties = UnitOfWork.GetUnitOfWork().Reservaties.FindAll(klant.Id);
            jaarReservaties = jaarReservaties.Where(r => r.Startmoment.Year == startMoment.Year);
            int amtOfYearReservations = jaarReservaties.ToList().Count;

            // Apply
            Reservatie reservatie = new Reservatie(klant, aankomstLocatie, vertrekLocatie, startMoment, uren, limosine, type, overUren, amtOfYearReservations);
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
