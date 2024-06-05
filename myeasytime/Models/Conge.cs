﻿using System;
using System.ComponentModel.DataAnnotations;

namespace myeasytime.Models
{
    public class Conge
    {
        public int CongeID { get; set; }

        [Display(Name = "Type")]
        public string type { get; set; }

        [Display(Name = "Name of WBS")]
        public string namewbs { get; set; }

        [Display(Name = "WBS")]
        public string wbs { get; set; }

    }
}
