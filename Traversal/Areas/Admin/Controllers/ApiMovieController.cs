using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Areas.Admin.Models;
using X.PagedList;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class ApiMovieController : Controller
    {
        public async Task<IActionResult> Index(int page = 1)
        {
            List<ApiMovie> movies = new List<ApiMovie>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
            {
        { "X-RapidAPI-Key", "44b735a026msh0f7832ed6fb2dcbp119c05jsn56a0dd1fe99d" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                movies = JsonConvert.DeserializeObject<List<ApiMovie>>(body);
                return View(movies.ToPagedList(page, 5));
            }
        }
    }
}
