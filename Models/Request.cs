using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBankManagementSystem.Models
{
    public class Request
    {
     



        public int requestid { get; set; }

        [Required(ErrorMessage = "Please Enter Donor Name")]
        [Display(Name = "Donor Name")]
        [DataType(DataType.Text)]
        public int donorid { get; set; }



        [Required(ErrorMessage = "Please Enter Blood Group")]
        [Display(Name = "Donor Name")]
        [DataType(DataType.Text)]
        public string fullname { get; set; }



        public int bloodgroupid { get; set; }



        [Required(ErrorMessage = "Please Enter Blood Group")]
        [Display(Name = "Blood Group")]
        public string bloodgroup { get; set; }
       

        public int bloodbankid { get; set; }



        [Required(ErrorMessage = "Please Enter Blood Bank Name")]
        [Display(Name = "Blood Bank Name")]
        public string name { get; set; }

        

        [Display(Name = "Quantity mL")]
        [DataType(DataType.Text)]
        public string quantity { get; set; }

        [Display(Name = "Date Time")]
        public DateTime date_time { get; set; }



        public virtual Donor Donor { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }
        public virtual BloodBank BloodBank { get; set; }
    }
}