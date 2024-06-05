using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myeasytime.Data;
using myeasytime.Models;

namespace myeasytime.Pages.Admin.Conges
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly myeasytime.Data.DataContext _context;

        public EditModel(myeasytime.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Conge Conge { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Conge = await _context.Conges.FirstOrDefaultAsync(m => m.CongeID == id);

            if (Conge == null)
            {
                return NotFound();
            }
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

            //_context.Attach(Conge).State = EntityState.Modified;
            _context.Update(Conge);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongeExists(Conge.CongeID))
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

        private bool CongeExists(int id)
        {
            return _context.Conges.Any(e => e.CongeID == id);
        }
    }
}
