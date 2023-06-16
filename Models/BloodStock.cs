using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloodBankManagementSystem.Models
{
    public class BloodStock
    {
     
       
       
       
      public int bloodstockid { get; set; }

        [Display(Name = "Quantity mL")]
        public int quantity { get; set; }

        [Display(Name = "Blood Group")]
        public int bloodgroupid { get; set; }

        [Display(Name = "Blood Group")]
        public string bloodgroup { get; set;}

        [Display(Name = "Blood Bank Name")]
        public int bloodbankid { get; set; }


        [Display(Name = "Blood Bank Name")]
        public string name { get; set;}


        [Display(Name = "Blood Type")]
        public int bloodtypeid { get; set; }

        [Display(Name = "Blood Type")]
        public string bloodtype { get; set; }

        [Display(Name = "Date Time")]
        public DateTime date_time { get; set; }

        public virtual Bloodtypes Bloodtypes { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }
        public virtual BloodBank BloodBank { get; set; }
    }
}