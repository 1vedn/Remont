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

namespace zayavkiremont.Pages
{
    /// <summary>
    /// Логика взаимодействия для Executors.xaml
    /// </summary>
    public partial class Executors : Page
    {
        public Executors()
        {
            InitializeComponent();
            DataGridExecutors.ItemsSource = Entities.GetContext().FaultTypes.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}      
