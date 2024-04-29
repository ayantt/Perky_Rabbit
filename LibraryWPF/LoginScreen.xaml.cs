using System.Net.Http;
using System.Windows;
using System.Net.Http.Headers;
using LibraryWPF.VM;
using System.Net.Http.Json;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        HttpClient client = new HttpClient();
        public LoginScreen()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var loginApiUrl = "https://localhost:7060/login";

            LoginVM vm = new LoginVM()
            {
                Username = txtUserName.Text,
                Password = txtPass.Password
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );

            var response = await client.PostAsJsonAsync(loginApiUrl, vm);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResVM>();

                if(loginResponse!= null && loginResponse.LoginStatus) 
                {
                    SessionManager.SetValue("UserID", loginResponse.UserId);

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.");
                }
            }
            else
            {
                
            }
        }
    }
}
