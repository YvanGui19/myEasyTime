using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using myeasytime.Data;
using myeasytime.Models;

namespace myeasytime.Pages.Admin.Conges
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly myeasytime.Data.DataContext _context;

        public DeleteModel(myeasytime.Data.DataContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Conge = await _context.Conges.FindAsync(id);

            if (Conge != null)
            {
                _context.Conges.Remove(Conge);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
