using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBankManagementSystem.Areas.Admin.Model
{
    public class Stockblood
    {


        [Display(Name = "Blood Stock ID")]
        public int bloodstockid { get; set; }

        [Display(Name = "Blood Quantity")]
        public int quantity { get; set; }

        [Display(Name = "Blood Group")]
        public int bloodgroupid { get; set; }



        [Display(Name = "Blood Bank Name")]
        public int bloodbankid { get; set; }





        [Display(Name = "Blood Type")]
        public int bloodtypeid { get; set; }




        [Display(Name = "Date Time")]
        public DateTime date_time { get; set; }
    }
}