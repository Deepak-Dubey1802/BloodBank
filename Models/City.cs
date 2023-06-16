using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBankManagementSystem.Models
{
    public class City
    {
        public int cityid { get; set; }


        [Display(Name = "City")]
        [DataType(DataType.Text)]
        public string cityname { get; set; }
        public int stateid { get; set; }


        [Display(Name = "State")]
        [DataType(DataType.Text)]
        public string statename { get; set; }


        public virtual State State { get; set; }

    }
}