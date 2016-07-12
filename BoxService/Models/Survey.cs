using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxService.Models
{
    public class Survey
    {
        [Key]
        public int SurveyID{ get; set; }

        [Display(Name = "PG blends or VG blends?")]
        public Blends Question1 { get; set; }

        [Display(Name = "Fruity or Desserts")]
        public Typechoice Question2 { get; set; }

    }
    public enum Blends
    {
        PG,
        VG 
    }
    public enum Typechoice
    {
        Fruity,
        Desserts
    }
}