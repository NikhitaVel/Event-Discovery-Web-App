using EventData;
using RecoData;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using FinalProject.Data;
using Microsoft.Extensions.Logging;

namespace FinalProject.Pages
{
    public class eventdetails : PageModel
    {

        static readonly HttpClient client = new HttpClient();

        private readonly ILogger<eventdetails> _logger;

        public eventdetails(ILogger<eventdetails> logger)
        {
            _logger = logger;
        }

        public bool HasUserResponded { get; set; }

        public void OnGet(string id)
        {
            // Sending back  event ID for reference
            ViewData["EventId"] = id;
            
            // grab the API key from THE SECRET STORE
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            SeatGeek sg_event = new SeatGeek();


            // Getting results from the api
            //var eventTask = client.GetAsync("https://api.seatgeek.com/2/events?client_id="+config["apikey_sn"]+"&venue.state=OH&venue.city=Cincinnati&id="+id);
            var eventTask = client.GetAsync("https://api.seatgeek.com/2/events?client_id=Mzc4MDQwMzh8MTY5ODI2NTUzMy4yMDYzODk&venue.state=OH&venue.city=Cincinnati&id=" + id);
            HttpResponseMessage eventResult = eventTask.Result;
            
            if (eventResult.IsSuccessStatusCode)
            {
                Task<string> readString = eventResult.Content.ReadAsStringAsync();
                string eventJsonString = readString.Result;
                sg_event = SeatGeek.FromJson(eventJsonString);
            }
            
            // Sending event details of selected event
            ViewData["Event"] = sg_event.Events[0];
            
            
            // Getting recommendations
            Recommendations event_recos = new Recommendations();
            
            // Getting results from the api
            // var recoTask = client.GetAsync("https://api.seatgeek.com/2/recommendations?client_id="+config["apikey_sn"]+"&events.id="+id);
            var recoTask = client.GetAsync("https://api.seatgeek.com/2/recommendations?client_id=Mzc4MDQwMzh8MTY5ODI2NTUzMy4yMDYzODk&events.id="+id);
            
            HttpResponseMessage recoResult = recoTask.Result;
            
            if (recoResult.IsSuccessStatusCode)
            {
                Task<string> recoString = recoResult.Content.ReadAsStringAsync();
                string recoJsonString = recoString.Result;
                event_recos = Recommendations.FromJson(recoJsonString);
            }
            
            // Sending recommendation event details of selected event
            ViewData["Recos"] = event_recos.RecommendationsRecommendations;

        }

    }
}