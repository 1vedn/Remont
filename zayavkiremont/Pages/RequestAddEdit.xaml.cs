using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace zayavkiremont.Pages
{
    public partial class RequestAddEdit : Page
    {
        int saveid,what;

        public RequestAddEdit(Requests selectedRequest)
        {
            InitializeComponent();

            ComboBoxEquipment.ItemsSource = Entities.GetContext().Equipment.ToList();
            ComboBoxFaultType.ItemsSource = Entities.GetContext().FaultTypes.ToList();
            ComboBoxClient.ItemsSource = Entities.GetContext().Clients.ToList();
            ComboBoxStatus.ItemsSource = Entities.GetContext().Statuses.ToList();
            ComboBoxExecutor.ItemsSource = Entities.GetContext().Executors.ToList();

            if (selectedRequest != null)
            {

                using (var db = new Entities())
                {
                    saveid=selectedRequest.RequestID;
                    TextBoxRequestNumber.Text = selectedRequest.RequestNumber;
                    DatePickerDateAdded.SelectedDate = selectedRequest.DateAdded;
                    ComboBoxEquipment.SelectedValue = selectedRequest.EquipmentID;
                    ComboBoxFaultType.SelectedValue = selectedRequest.FaultTypeID;
                    TextBoxProblemDescription.Text = selectedRequest.ProblemDescription;
                    ComboBoxClient.SelectedValue = selectedRequest.ClientID;
                    ComboBoxStatus.SelectedValue = selectedRequest.StatusID;
                    ComboBoxExecutor.SelectedValue = selectedRequest.ExecutorID;
                    ComboBoxPriority.Text = selectedRequest.Priority;
                    DatePickerCompletionDate.SelectedDate = selectedRequest.CompletionDate;
                    what = 1;
                }
                    
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    if (what == 0)
                    {
                            
                        {
                        Requests words = new Requests();
                            words.RequestNumber = TextBoxRequestNumber.Text;
                            words.DateAdded = DatePickerDateAdded.SelectedDate ?? DateTime.Now;
                            words.EquipmentID = (int)ComboBoxEquipment.SelectedValue;
                            words.FaultTypeID = (int)ComboBoxFaultType.SelectedValue;
                            words.ProblemDescription = TextBoxProblemDescription.Text;
                            words.ClientID = (int)ComboBoxClient.SelectedValue;
                            words.StatusID = (int)ComboBoxStatus.SelectedValue;
                            words.ExecutorID = (int)ComboBoxExecutor.SelectedValue;
                            words.Priority = ComboBoxPriority.Text;
                            words.CompletionDate = DatePickerCompletionDate.SelectedDate;
                            context.Requests.Add(words);
                            context.SaveChanges();
                        };

                    }
                    else
                    {
                        var existingPost = context.Requests.FirstOrDefault(p => p.RequestID == saveid);
                        existingPost.RequestNumber = TextBoxRequestNumber.Text;
                        existingPost.DateAdded = DatePickerDateAdded.SelectedDate ?? DateTime.Now;
                        existingPost.EquipmentID = (int)ComboBoxEquipment.SelectedValue;
                        existingPost.FaultTypeID = (int)ComboBoxFaultType.SelectedValue;
                        existingPost.ProblemDescription = TextBoxProblemDescription.Text;
                        existingPost.ClientID = (int)ComboBoxClient.SelectedValue;
                        existingPost.StatusID = (int)ComboBoxStatus.SelectedValue;
                        existingPost.ExecutorID = (int)ComboBoxExecutor.SelectedValue;
                        existingPost.Priority = ComboBoxPriority.Text;
                        existingPost.CompletionDate = DatePickerCompletionDate.SelectedDate;
                        context.Entry(existingPost).State = EntityState.Modified;

                        context.SaveChanges();
                    }
                    MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService?.Navigate(new RequestsPage());
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
