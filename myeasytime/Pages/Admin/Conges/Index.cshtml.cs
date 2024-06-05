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
    public class IndexModel : PageModel
    {
        private readonly myeasytime.Data.DataContext _context;

        public IndexModel(myeasytime.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Conge> Conge { get;set; }

        public async Task OnGetAsync()
        {
            Conge = await _context.Conges.ToListAsync();
        }
    }
}
