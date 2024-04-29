using LibraryWPF.VM;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LibraryWPF
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var books = await GetBookList();
            this.DataContext = books;
        }

        public async Task<List<BookDetailVM>> GetBookList()
        {
            var apiUrl = "https://localhost:7060/GetBooks";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var book = JsonSerializer.Deserialize<List<BookDetailVM>>(jsonString);
                return book;
            }
            else
            {
                MessageBox.Show("Failed to retrieve books.");
                return new List<BookDetailVM>();
            }
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var bookId = (int)button.Tag;
                BorrowBook(bookId);
            }
        }

        private async void BorrowBook(int bookId)
        {
            var apiUrl = "https://localhost:7060/InsertBorrow";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            BorrowBookVM borrow = new BorrowBookVM()
            {
                BookId = bookId,
                MemberId= SessionManager.GetValue<int>("UserID"),
            };

            var borrowResponse = await (await client.PostAsJsonAsync(apiUrl, borrow)).Content.ReadFromJsonAsync<int>();

            if(borrowResponse==0)
            {
                MessageBox.Show("Book borrowed successfully!");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var bookId = (int)button.Tag;
                ReturnBookAsync(bookId);
            }
        }

        private async Task ReturnBookAsync(int bookId)
        {
            var apiUrl = "https://localhost:7060/BorrowReturn";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            BorrowBookVM borrow = new BorrowBookVM()
            {
                BookId = bookId,
                MemberId = SessionManager.GetValue<int>("UserID"),
            };

            var borrowResponse = await(await client.PostAsJsonAsync(apiUrl, borrow)).Content.ReadFromJsonAsync<int>();

            if (borrowResponse == 0)
            {
                MessageBox.Show("Book returned successfully!", "Alert");
            }
            else if (borrowResponse == 1)
            {
                MessageBox.Show("Book not borrowed", "Alert");
            }
            else
            {
                MessageBox.Show("Something went wrong.", "Alert");
            }
        }
    }
}
