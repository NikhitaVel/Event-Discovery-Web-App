using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.FormResponses
{
    public class DetailsModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public DetailsModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public FormResponse FormResponse { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FormResponse == null)
            {
                return NotFound();
            }

            var formresponse = await _context.FormResponse.FirstOrDefaultAsync(m => m.Id == id);
            if (formresponse == null)
            {
                return NotFound();
            }
            else 
            {
                FormResponse = formresponse;
            }
            return Page();
        }
    }
}
