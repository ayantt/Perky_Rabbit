using LibraryWeb.VM;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var books = await GetBooksAsync();
                return View(books.ToArray());
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<List<BookDetailVM>> GetBooksAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var apiUrl = "https://localhost:7060/GetBooks";

            var response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<BookDetailVM>>(jsonString);
            }
            else
            {
                throw new InvalidOperationException("Could not retrieve books: " + response.StatusCode);
            }
        }


        [HttpPost]
        public async Task<IActionResult> BorrowBookAsync(int id)
        {
            BorrowBookVM bb = new BorrowBookVM()
            {
                MemberId = Convert.ToInt32(HttpContext.Session.GetString("UserId")),
                BookId = id,
            };

            var client = _httpClientFactory.CreateClient();
            var apiUrl = "https://localhost:7060/InsertBorrow";

            try
            {
                var response = await client.PostAsJsonAsync(apiUrl, bb);

                if (response.IsSuccessStatusCode)
                {
                    var borrowResponse = await response.Content.ReadFromJsonAsync<int>();

                    if (borrowResponse == 0)
                    {
                        return Json(new { res = borrowResponse });
                    }
                    else
                    {
                        return Json(new { res = 1 });
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong.");
            }

            return Json(new { res = 1 });
        }

        [HttpPost]
        public async Task<IActionResult> ReturnBookAsync(int id)
        {
            BorrowBookVM bb = new BorrowBookVM()
            {
                MemberId = Convert.ToInt32(HttpContext.Session.GetString("UserId")),
                BookId = id,
            };

            var client = _httpClientFactory.CreateClient();
            var apiUrl = "https://localhost:7060/BorrowReturn";

            try
            {
                var response = await client.PostAsJsonAsync(apiUrl, bb);

                if (response.IsSuccessStatusCode)
                {
                    var returnResponse = await response.Content.ReadFromJsonAsync<int>();

                    if (returnResponse == 0)
                    {
                        return Json(new { res = returnResponse });
                    }
                    else
                    {
                        return Json(new { res = 1 });
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong.");
            }

            return Json(new { res = 1 });
        }

    }

}
