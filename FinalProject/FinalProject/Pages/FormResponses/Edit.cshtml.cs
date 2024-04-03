using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.FormResponses
{
    public class EditModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public EditModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FormResponse FormResponse { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FormResponse == null)
            {
                return NotFound();
            }

            var formresponse =  await _context.FormResponse.FirstOrDefaultAsync(m => m.Id == id);
            if (formresponse == null)
            {
                return NotFound();
            }
            FormResponse = formresponse;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FormResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormResponseExists(FormResponse.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FormResponseExists(int id)
        {
          return (_context.FormResponse?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
