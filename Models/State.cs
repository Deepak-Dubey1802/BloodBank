using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBankManagementSystem.Models
{
    public class State
    {
        public int stateid { get; set; }

        [Required(ErrorMessage = "Please Enter State")]
        [Display(Name = "State")]
        [DataType(DataType.Text)]
        public string statename { get; set; }

        public int countryid { get; set; }

        
        [Display(Name = "Country")]
        [DataType(DataType.Text)]
        public string countryname { get; set; }



        public virtual Country Country { get; set; }
    }
}