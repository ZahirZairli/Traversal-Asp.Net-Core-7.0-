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
    public class HotelsApiController : Controller
    {
        public async Task<IActionResult> Index(int page = 1,string UserName="",string City="")
        {
            if (City =="")
            {
                City = "-2705195";
            }
            ViewBag.city = City;
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/search?checkin_date=2023-09-27&dest_type=city&units=metric&checkout_date=2023-09-28&adults_number=2&order_by=popularity&dest_id={City}&filter_by_currency=AZN&locale=tr&room_number=1&children_number=2&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&include_adjacency=true"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", "44b735a026msh0f7832ed6fb2dcbp119c05jsn56a0dd1fe99d" },
                        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                    },
                };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<HotelsApi>(body);
                if (UserName != null)
                {
                    var filteredExchangeRates = values.result.Where(e => e.hotel_name.ToUpper().Contains(UserName.ToUpper())).ToPagedList(page, 10);
                    return View(filteredExchangeRates);
                }
                return View(values.result.ToPagedList(page, 10));
            }
        }
    }
}
