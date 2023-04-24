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
    public class ApiExchangeController : Controller
    {
        public async Task<IActionResult> Index(int page = 1 , string UserName = "")
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=AZN&locale=en-gb"),
                Headers =
                {
                    { "X-RapidAPI-Key", "a5e7a12b02mshe0edeec2c316e9cp1a71dajsne85842426f8e" },
                    { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeApi2>(body);
                if (UserName == null)
                {
                    return View(values.exchange_rates.ToPagedList(page, 10));
                }
                else {
                    var filteredExchangeRates = values.exchange_rates.Where(e => e.currency.Contains(UserName.ToUpper())).ToPagedList(page, 10);
                    return View(filteredExchangeRates);
                }
            }
        }
    }
}
