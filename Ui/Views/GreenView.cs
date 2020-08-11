using DataLayer;
using DomainLayer;
using DomainLayer.Models;
using System;
using System.Collections;
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
    /// Interaction logic for UserControl3.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        List<Reservatie> reservaties;
        public UserControl3(IEnumerable<Reservatie> reservaties)
        {
            InitializeComponent();

            this.reservaties = reservaties.ToList();

            ReservatieManager reservatieManager = new ReservatieManager(UnitOfWork.GetUnitOfWork());
            reserveringdatalabel.Content = reservatieManager.GetReservatieInfo(reservaties.First());
        }

        private void ShowReservatie(object sender, RoutedEventArgs e)
        {
            
        }

        public UserControl3()
        {

        }
    }
}
