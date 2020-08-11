﻿using DataLayer;
using DomainLayer;
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
using Ui.ViewModels;

namespace Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //UnitOfWork unitOfWork = new UnitOfWork(new ServicesContext());
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RedViewClicked(object sender, RoutedEventArgs e)
        {
            DataContext = new RedViewModel();
        }

        private void BlueButtonClicked(object sender, RoutedEventArgs e)
        {
            DataContext = new BlueViewModel();
        }
    }
}
