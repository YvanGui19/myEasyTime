using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using myeasytime.Data;
using myeasytime.Models;

namespace myeasytime.Pages.Admin.Conges
{
    public class DetailsModel : PageModel
    {
        private readonly myeasytime.Data.DataContext _context;

        public DetailsModel(myeasytime.Data.DataContext context)
        {
            _context = context;
        }

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
    }
}
