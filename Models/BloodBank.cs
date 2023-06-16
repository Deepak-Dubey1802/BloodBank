using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBankManagementSystem.Models
{
    public class BloodBank
    {
        public int bloodbankid { get; set; }

        [Display(Name = "Blood Bank Name")]
        public string name { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name = "Mobile NO")]
        public string phoneno { get; set; }

        [Display(Name = "Website")]
        public string website { get; set; }

        [Display(Name = "Email ID")]
        public string email { get; set; }

        [Display(Name = "Blood Group")]
        public int bloodgroupid { get; set; }

        public string bloodgroup { get; set; }


        [Display(Name = "City")]
        public int cityid { get; set; }

        [Display(Name = "City")]
        public string cityname { get; set; }

        [Display(Name = "State")]
        public int stateid { get; set; }

        [Display(Name = "State")]
        public string statename { get; set; }

        [Display(Name = "Country")]
        public int countryid { get; set; }

        [Display(Name = "Country")]
        public string countryname { get; set; }

        public virtual BloodGroup BloodGroup { get; set; }
        public virtual City City { get; set; }
        public virtual State State { get; set; }
        public virtual Country country { get; set; }


    }
}