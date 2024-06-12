using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace myeasytime.Models
{
    public class Conge
    {
        [JsonIgnore] /*permet d'ignorer CongeID dans le Json*/
        public int CongeID { get; set; }

        [Display(Name = "Type")]
        public string type { get; set; }

        [Display(Name = "Name of WBS")]
        public string namewbs { get; set; }

        [Display(Name = "WBS")]
        public string wbs { get; set; }

    }
}
