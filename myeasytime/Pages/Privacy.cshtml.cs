using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using myeasytime.Data;
using myeasytime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myeasytime.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        DataContext dataContext;

        public PrivacyModel(ILogger<PrivacyModel> logger, DataContext dataContext)
        {
            _logger = logger;
            this.dataContext = dataContext;
        }

        public void OnGet()
        {
            //Test accès BD
            /*var conge = new Conge() { type = "CongeTest", namewbs = "VacTest", wbs = "007ATR" };
            dataContext.Conges.Add(conge);
            dataContext.SaveChanges();*/
        }
    }
}
