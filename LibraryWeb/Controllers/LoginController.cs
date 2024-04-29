using LibraryWeb.VM;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("LoginCheck")]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var loginApiUrl = "https://localhost:7060/login";

                try
                {
                    var response = await client.PostAsJsonAsync(loginApiUrl, model);

                    if (response.IsSuccessStatusCode)
                    {
                        var loginResponse = await response.Content.ReadFromJsonAsync<LoginResVM>();

                        if (loginResponse != null && loginResponse.LoginStatus)
                        {
                            HttpContext.Session.SetString("UserId", Convert.ToString(loginResponse.UserId));
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Login failed. Please check your username and password.");
                            return View("Index", model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login service is down, please check later.");
                        return View("Index", model);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View("Index", model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View("Index", model);
            }            
        }
    }
}
