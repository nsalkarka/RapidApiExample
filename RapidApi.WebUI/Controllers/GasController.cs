using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.WebUI.Models;

namespace RapidApi.WebUI.Controllers
{
    public class GasController : Controller
    {
        public async Task<IActionResult> Index()
        {

            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://gas-price.p.rapidapi.com/europeanCountries"),
                Headers =
    {
        { "x-rapidapi-key", "a41975009dmsh8e32d64062a5468p1445ebjsnd7ef0058dc43" },
        { "x-rapidapi-host", "gas-price.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<GasPriceViewModel>(body);
                return View(values.results);
            }

        }
    }
}
