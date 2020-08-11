using DataLayer;
using DataLayer.Repositories;
using DomainLayer;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            DateTime startMoment = DateTime.Parse(this.StartMomentPicker.ToString());
            startMoment.AddHours(int.Parse(UurTextBox.Text));
            int uren = int.Parse(DuurTextBox.Text);
            Klant klant = (Klant)comboBoxKlanten.SelectedItem;
            string vertrekLocatie = VertrekPlaatsComboBox.SelectedIndex.ToString();
            string aankomstLocatie = AankomstPlaatsComboBox.SelectedIndex.ToString();
            Limosine limosine = (Limosine)comboBoxLimosines.SelectedItem;
            // Check

            // Apply
            Reservatie reservatie = new Reservatie(klant, aankomstLocatie, vertrekLocatie, startMoment, uren, limosine, type);
            UnitOfWork.GetUnitOfWork().Reservaties.AddReservatie(reservatie);
            UnitOfWork.GetUnitOfWork().Complete();
        }
    }
}
