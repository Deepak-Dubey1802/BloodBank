using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBankManagementSystem.Models
{
    public class Bloodtypes
    {
        [Display(Name = "Blood Type")]
        public int bloodtypeid { get; set; }

        [Display(Name = "Blood Components")]
        public string bloodtype { get; set; }
    }
}