namespace FinalProject.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinalProject;

    public class StatesModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        private readonly ILogger<StatesModel> _logger;
        List<States> states = new List<States>();
        public StatesModel(ILogger<StatesModel> logger)
        {
            _logger = logger;
        }
        public void OnGet(string stateName, string stateCode)
        {
            try
            {
                var task = client.GetAsync("https://neighborhoodwatch.azurewebsites.net/api/values");
                HttpResponseMessage result = task.Result;

                if (result.IsSuccessStatusCode)
                {
                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string jsonString = readString.Result;
                    states = States.FromJson(jsonString);
                }

                ViewData["States"] = states;
                ViewData["Code"] = stateCode;
                ViewData["StateName"] = stateName;

                foreach (States st in states)
                {
                    if (st.Name == stateName && st.Code.ToLower() == stateCode.ToLower())
                    {
                        ViewData["CorrectGuess"] = true;
                        break;
                    }
                    else ViewData["CorrectGuess"] = false;
                }
            }
            catch (Exception e)
            {
                ViewData["States"] = "No Data Available";
                ViewData["Code"] = "No Data Available";
                ViewData["StateName"] = "No Data Available";
            }
            
        }
    }

