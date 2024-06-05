using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using myeasytime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myeasytime.Pages
{
    public class IndexModel : PageModel
    {
        private readonly myeasytime.Data.DataContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(myeasytime.Data.DataContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Conge> Conge { get; set; }
        public DateTime[] Days { get; private set; }
     

        [BindProperty]
        public string SelectedDate { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }

        [BindProperty]
        public string LeaveType { get; set; }

        public string DateOfNow { get; set; }

        public async Task OnGetAsync()
        {
            Conge = await _context.Conges.ToListAsync();

            var now = DateTime.Now;
            var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
            var daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
            Days = new DateTime[daysInMonth];
            for (int i = 0; i < daysInMonth; i++)
            {
                Days[i] = firstDayOfMonth.AddDays(i);
            }

            DateOfNow = now.ToString("MMMM yyyy");
        }

        public IActionResult OnPostSubmit()
        {
            // Traitez les données soumises ici
            // Exemple: enregistrer dans une base de données

            return RedirectToPage();
        }

    }
}
