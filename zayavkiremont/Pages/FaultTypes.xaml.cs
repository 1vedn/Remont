﻿using System;
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

namespace zayavkiremont.Pages
{
    /// <summary>
    /// Логика взаимодействия для FaultTypes.xaml
    /// </summary>
    public partial class FaultTypes : Page
    {
        public FaultTypes()
        {
            InitializeComponent();
            DataGridFaultTypes.ItemsSource = Entities.GetContext().FaultTypes.ToList();
            }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}