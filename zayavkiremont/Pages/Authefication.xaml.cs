using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace zayavkiremont.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authefication.xaml
    /// </summary>
    public partial class Authefication : Page
    {
        public Authefication()
        {
            InitializeComponent();
        }

        
        
        public static string GetHash(string password)
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }

        public void Auth(string login, string password)
        {

            using (var db = new Entities())
            {
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Введите логин и пароль");
                }
                else
                {
                    var user = db.Clients
                        .AsNoTracking()
                        .FirstOrDefault(u => u.Login == login && u.Password == password);
                    if (user == null || user.Password != password || user.Login != login)
                    {
                        MessageBox.Show("Пользователь с такими данными не найден!");
                    }
                    else
                    {
                        MessageBox.Show($"Здравствуйте, {user.Name}, Хорошего дня!");
                        switch (user.Role)
                        {
                            case "Admin":
                                NavigationService?.Navigate(new RequestsPage());
                                break;
                            case "User":
                                NavigationService?.Navigate(new RequestsPage());
                                break;
                        }
                    }
                }
            }

        }

        private void Open_click(object sender, RoutedEventArgs e)
        {
            Auth(login.Text, GetHash(password.Password));
        }
    }
}
