using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.WebUI.Models;

namespace RapidApi.WebUI.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb236.p.rapidapi.com/imdb/top250-movies"),
                Headers =
    {
        { "x-rapidapi-key", "a41975009dmsh8e32d64062a5468p1445ebjsnd7ef0058dc43" },
        { "x-rapidapi-host", "imdb236.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var jsonbody = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ImdbViewModel.Movie>>(jsonbody);

                var dramaList = values.Where(x => x.genres.Contains("Drama")).ToList();
                return View(dramaList);
            }

        }
    }
}
