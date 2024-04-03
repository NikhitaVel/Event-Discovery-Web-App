using Microsoft.AspNetCore.Mvc.RazorPages;
using EventData;

namespace FinalProject.Pages
{
    public class Theater : PageModel
    {
        static readonly HttpClient client = new HttpClient();

        private readonly ILogger<Theater> _logger;

        public Theater(ILogger<Theater> logger)
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
            var eventTask = client.GetAsync("https://api.seatgeek.com/2/events?client_id=Mzc4MDQwMzh8MTY5ODI2NTUzMy4yMDYzODk&venue.state=OH&venue.city=Cincinnati&taxonomies.name=theater");
            HttpResponseMessage eventResult = eventTask.Result;
            SeatGeek sg_event = new SeatGeek();
            if (eventResult.IsSuccessStatusCode)
            {
                Task<string> readString = eventResult.Content.ReadAsStringAsync();
                string eventJsonString = readString.Result;
                sg_event = SeatGeek.FromJson(eventJsonString);
            }
            ViewData["Events"] = sg_event.Events;

            // using this block to save json data locally so that we don't hit the API repeatedly
            /*SeatGeek sg_event = new SeatGeek();
            string eventJsonString = System.IO.File.ReadAllText("sg_event_sample.txt");
            sg_event = SeatGeek.FromJson(eventJsonString);
            ViewData["Events"] = sg_event.Events;*/
        }
    }
}



