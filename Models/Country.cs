using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBankManagementSystem.Models
{
    public class Country
    {
        public int countryid { get; set; }
        [Required(ErrorMessage = "Please Enter Country")]
        [Display(Name = "Country")]
        [DataType(DataType.Text)]
        public string countryname { get; set; }
    }
}