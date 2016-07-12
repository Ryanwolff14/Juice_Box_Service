using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoxService.Models
{
    public class Admin
    {
        [Key]
        public int? ID { get; set; }
        [Display(Name = "#  of Accounts")]
        public int? NumberOfAccounts { get; set; }
        [Display(Name = "Total Paid Monthly")]
        public double? MonthlyTotal { get; set; }
        [Display(Name = "Max VG Fruity")]
        public double? PercentFruityVG { get; set; }
        [Display(Name = "Max PG Fruity")]
        public double? PercentFruityPG { get; set; }
        [Display(Name = "Max VG Dessert")]
        public double? PercentDessertVG { get; set; }
        [Display(Name = "Max PG Dessert")]
        public double? PercentDessertPG { get; set; }
    }
}