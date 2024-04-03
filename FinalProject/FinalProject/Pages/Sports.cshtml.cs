using EventData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{
    public class SportsModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();

        private readonly ILogger<SportsModel> _logger;

        public SportsModel(ILogger<SportsModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            // grab the API key from THE SECRET STORE
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            // Getting results from the api - NEED TO ADD DATE PARAMETERS
            // var eventTask = client.GetAsync("https://api.seatgeek.com/2/events?client_id=" + config["apikey_sn"] + "&venue.state=OH&venue.city=Cincinnati&taxonomies.name=sports");
            var eventTask = client.GetAsync("https://api.seatgeek.com/2/events?client_id=Mzc4MDQwMzh8MTY5ODI2NTUzMy4yMDYzODk&venue.state=OH&venue.city=Cincinnati&taxonomies.name=sports");

            HttpResponseMessage eventResult = eventTask.Result;
            SeatGeek sg_event = new SeatGeek();
            if (eventResult.IsSuccessStatusCode)
            {
                Task<string> readString = eventResult.Content.ReadAsStringAsync();
                string eventJsonString = readString.Result;
                sg_event = SeatGeek.FromJson(eventJsonString);
            }
            ViewData["Events"] = sg_event.Events;

        }
    }
}
