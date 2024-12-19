using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace zayavkiremont.Pages
{
    /// <summary>
    /// Логика взаимодействия для RequestsPage.xaml
    /// </summary>
    public partial class RequestsPage : Page
    {
        public RequestsPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // Загружаем данные из базы в DataGrid
            DataGridRequests.ItemsSource = Entities.GetContext().Requests.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            Frame frame = window.FindName("MainFrame") as Frame;
            frame.Navigate(new Pages.RequestAddEdit(null));
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            Frame frame = window.FindName("MainFrame") as Frame;
            var selected = DataGridRequests.SelectedItem as Requests;
            if (selected != null)
            {
                frame.Navigate(new Pages.RequestAddEdit(selected));
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения");
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var del = DataGridRequests.SelectedItems.Cast<Requests>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить строки {del.Count}", "Без возможмости восстановления ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                Entities.GetContext().Requests.RemoveRange((System.Collections.Generic.IEnumerable<zayavkiremont.Requests>)del);
                Entities.GetContext().SaveChanges();
                DataGridRequests.ItemsSource = Entities.GetContext().Requests.ToList();

            }
            else
            {
                MessageBox.Show("Выберите строки для удаления ");
            }
        }

        private void ButtonRev_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Statuses());
        }
        private void UpdateUsers()
        {
            LoadData();

            //осуществляем поиск по Ф.И.О. без учета регистра букв
            DataGridRequests.ItemsSource = Entities.GetContext().Requests.ToList().Where(x => x.RequestNumber.ToLower().Contains(Numfilter.Text.ToLower())).ToList();
        }

        private void Numfilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUsers();
        }
    }
}
