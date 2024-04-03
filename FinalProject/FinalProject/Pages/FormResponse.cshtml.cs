using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FinalProject.Pages
{
    public class FormResponseModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public FormResponseModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AttendanceForm([FromQuery] string attendance, [FromQuery] int eventid)
        {
            if (!string.IsNullOrEmpty(attendance))
            {
                    FormResponse formResponse = new FormResponse
                    {
                        EventId = eventid,
                        Response = attendance.Equals("yes", StringComparison.OrdinalIgnoreCase) ? "yes" : "no"
                    };

                    // Save to the database
                    _context.FormResponse.Add(formResponse);
                    _context.SaveChanges();

            }
            return null;

        }

    }
}