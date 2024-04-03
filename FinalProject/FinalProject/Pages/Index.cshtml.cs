using Microsoft.AspNetCore.Mvc.RazorPages;
using EventData;

namespace FinalProject.Pages
{
    public class IndexModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        
        private readonly ILogger<IndexModel> _logger;
        
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        
        public void OnGet()
        {
            // grab the API key from THE SECRET STORE
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            SeatGeek sg_event = new SeatGeek();
            // Getting results from the api - NEED TO ADD DATE PARAMETERS
            var eventTask = client.GetAsync("https://api.seatgeek.com/2/events?client_id=Mzc4MDQwMzh8MTY5ODI2NTUzMy4yMDYzODk&venue.state=OH&venue.city=Cincinnati&per_page=30");
            HttpResponseMessage eventResult = eventTask.Result;
            
            if (eventResult.IsSuccessStatusCode)
            {
                Task<string> readString = eventResult.Content.ReadAsStringAsync();
                string eventJsonString = readString.Result;
                sg_event = SeatGeek.FromJson(eventJsonString);
            }
            ViewData["Events"] = sg_event.Events;
            EventRoster.allEvents = sg_event.Events;
        }
    }
}