using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using myeasytime.Data;
using myeasytime.Models;

namespace myeasytime.Pages.Admin.Conges
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly myeasytime.Data.DataContext _context;

        public CreateModel(myeasytime.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Conge Conge { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Conges.Add(Conge);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
