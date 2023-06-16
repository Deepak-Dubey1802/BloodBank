using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBankManagementSystem.Models
{
    public class RequestForm
    {
        [Required(ErrorMessage = "Please Enter Request Date")]
        [Display(Name = "Request Date")]
        [DataType(DataType.Date)]
        public DateTime requestdate { get; set; }


        [Required(ErrorMessage = "Please Enter Donor Name")]
        [Display(Name = "Donor Name")]
      
        public int donorid { get; set; }

        [Required(ErrorMessage = "Please Enter Blood Group")]
        [Display(Name = "Blood Group")]
        public int bloodgroupid { get; set; }
      


        [Required(ErrorMessage = "Please Enter Blood Bank Name")]
        [Display(Name = "Blood Bank Name")]
        public int bloodbankid { get; set; }
      


        [Required(ErrorMessage = "Please Blood Quantity")]
        [Display(Name = "Quantity")]

        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid blood quantity")]
        public int quantity { get; set; }

        public virtual Donor Donor { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }
        public virtual BloodBank BloodBank { get; set; }
    }
}