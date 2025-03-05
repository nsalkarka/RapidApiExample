using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.WebUI.Models;
using static RapidApi.WebUI.Models.HotelViewModel;

namespace RapidApi.WebUI.Controllers
{
    public class HotelFindController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
           
            return View(); 
            
        }

          [HttpPost]
        public async Task<IActionResult> Index(HotelFindViewModel _hotelFindViewModel)
        {
            
            return RedirectToAction("DestFind", _hotelFindViewModel); 
        }
        public async Task<IActionResult> DestFind(HotelFindViewModel _hotelFindViewModel)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={Uri.EscapeDataString(_hotelFindViewModel.destName)}"),
                Headers =
    {
        { "x-rapidapi-key", "a41975009dmsh8e32d64062a5468p1445ebjsnd7ef0058dc43" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<HotelDestination>(body);

                _hotelFindViewModel.destId = value.data[0].dest_id;
                
                return RedirectToAction("HotelSearch", _hotelFindViewModel); 
            }
        }

        public async Task<IActionResult> HotelSearch(HotelFindViewModel _hotelFindViewModel)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id={Uri.EscapeDataString(_hotelFindViewModel.destId)}&search_type=CITY&arrival_date={_hotelFindViewModel.arrivalDate.Value.ToString("yyyy-MM-dd")}&departure_date={_hotelFindViewModel.departureDate.Value.ToString("yyyy-MM-dd")}&adults=1&children_age=0%2C17&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=usd"),
                Headers =
    {
        { "x-rapidapi-key", "a41975009dmsh8e32d64062a5468p1445ebjsnd7ef0058dc43" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var hotels = JsonConvert.DeserializeObject<HotelViewModel>(body);
                return View("Index",hotels.data.hotels);
            }
        }
    }
}
