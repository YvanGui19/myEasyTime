using System;
using System.ComponentModel.DataAnnotations;

namespace myeasytime.Models
{
    public class DemandeConge
    {
        public int DemandeCongeID { get; set; }

        [Display(Name = "Date de début")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Date de fin")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Type de congé")]
        public string LeaveType { get; set; }
    }
}
