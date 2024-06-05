using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myeasytime.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

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
        //public List<DateTime> Days { get; set; }

        public void OnGet()
        {
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
