using EventData;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{
    public class Search : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        
        public async Task OnGetAsync(string searchString)
        {
            // grab the API key from THE SECRET STORE
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            
            // Getting results from the api - NEED TO ADD DATE PARAMETERS
            // var eventTask = client.GetAsync("https://api.seatgeek.com/2/events?client_id="+config["apikey_sn"]+"&venue.state=OH&venue.city=Cincinnati&q="+searchString);
            var eventTask = client.GetAsync("https://api.seatgeek.com/2/events?client_id=Mzc4MDQwMzh8MTY5ODI2NTUzMy4yMDYzODk&venue.state=OH&venue.city=Cincinnati&q="+searchString);
            
            HttpResponseMessage eventResult = eventTask.Result;
            SeatGeek sg_event = new SeatGeek();
            if (eventResult.IsSuccessStatusCode)
            {
                Task<string> readString = eventResult.Content.ReadAsStringAsync();
                string eventJsonString = readString.Result;
                sg_event = SeatGeek.FromJson(eventJsonString);
            }
            ViewData["Events"] = sg_event.Events;
            ViewData["searchString"] = searchString;
            // ViewData["Events"] = searchString;
        }
    }
}