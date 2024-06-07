using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using myeasytime.Models;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myeasytime.Pages
{
    public class IndexModel : PageModel //...
    {
        private readonly myeasytime.Data.DataContext _context; //pour accéder à la base de données
        private readonly ILogger<IndexModel> _logger; //pour enregistrer les messages de journalisation

        public IndexModel(myeasytime.Data.DataContext context, ILogger<IndexModel> logger) // constructeur de la classe IndexModel
        {
            _context = context; //initialise _context
            _logger = logger; //initialise _logger
        }

        public IList<Conge> Conge { get; set; } //déclaration de la propriété Conge qui est une liste de congés
        public DateTime[] Days { get; private set; } //déclaration de la propriété Days qui est un tableau de dates
     

        [BindProperty] //les propriétés avec les BindProperty sont les déclarations des propriétés qui sont liées aux données du formulaire
        public string SelectedDate { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }

        [BindProperty]
        public string LeaveType { get; set; }

        public string DateOfNow { get; set; } //déclaration de la propriété DateOfNow qui contiendra la date actuelle

        public int MonthOffset { get; set; }
        public DateTime CurrentMonth { get; set; }

        public async Task OnGetAsync(int monthOffset = 0) //méthode qui :
        {
            MonthOffset = monthOffset;
            CurrentMonth = DateTime.Now.AddMonths(monthOffset);
            Conge = await _context.Conges.ToListAsync(); //récupère la liste des types de congé de la DB

            var now = CurrentMonth; //calcule les dates de tous les jours du mois courant
            var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
            var daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
            Days = new DateTime[daysInMonth];
            for (int i = 0; i < daysInMonth; i++)
            {
                Days[i] = firstDayOfMonth.AddDays(i);
            }

            DateOfNow = now.ToString("MMMM yyyy"); //stock la date actuelle
        }

        public async Task<IActionResult> OnPostSubmit() //méthode de vérification du formulaire
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string isoStartDate = ConvertDateToISO8601(this.StartDate); //convertit les champs date en format lisible et réutilisable pour et par la DB
            string isoEndDate = ConvertDateToISO8601(this.EndDate);

            if (isoStartDate == null || isoEndDate == null) //vérifie que les champs date soient remplit
            {
                return Page();
            }

            var demandeconge = new DemandeConge //crée une nouvelle demande de congé dans la DB
            {
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                LeaveType = this.LeaveType
            };

            _context.DemandesConges.Add(demandeconge); //ajout de la nouvelle demande de congé à la DB
            await _context.SaveChangesAsync();//enregistre les modifs

            _logger.LogInformation("Nouveau congé enregistré avec succès : {StartDate} à {EndDate}, Type : {LeaveType}", StartDate, EndDate, LeaveType);

            TempData["SuccessMessage"] = "Les données ont été envoyées avec succès à la base de données.";

            return RedirectToPage("./Index");

        }

        private string ConvertDateToISO8601(DateTime date) //méthode de convertion de la date au format de la DB
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
