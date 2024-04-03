﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.FormResponses
{
    public class CreateModel : PageModel
    {
        private readonly FinalProject.Data.ApplicationDbContext _context;

        public CreateModel(FinalProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FormResponse FormResponse { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FormResponse == null || FormResponse == null)
            {
                return Page();
            }

            _context.FormResponse.Add(FormResponse);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
