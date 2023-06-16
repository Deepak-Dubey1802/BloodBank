using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBankManagementSystem.Models
{
    public class Registration
    {
       
        public int donorid { get; set; }
        public int genderid { get; set; }

        [Required(ErrorMessage = "Please Enter Blood Group")]
        [Display(Name = "Blood Group")]
        // [DataType(DataType.Password)]
        public int bloodgroupid { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        [Display(Name = "City")]
        [DataType(DataType.Text)]
        public int cityid { get; set; }

        [Required(ErrorMessage = "Please Enter State")]
        [Display(Name = "State")]
        [DataType(DataType.Text)]
        public int stateid { get; set; }

        [Required(ErrorMessage = "Please Enter Country")]
        [Display(Name = "Country")]
        [DataType(DataType.Text)]
        public int countryid { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Full Name"), MaxLength(30)]
        [Display(Name = "Full Name")]
        public string fullname { get; set; }

        [Required(ErrorMessage = "Please Enter Last Donation Date")]
        [Display(Name = "Last Donation Date")]
        [DataType(DataType.Date)]
        public DateTime lastdonationdate { get; set; }

        [Required(ErrorMessage = "You must provide a mobile number")]
        [Display(Name = "Mobile No")]
        [StringLength(13, MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Mobile number")]
        public string phoneno { get; set; }

        [Required(ErrorMessage = "Please Enter Pan No")]
        [Display(Name = "Pan No")]
        [RegularExpression(@"^[A-Z]{5}[0-9]{4}[A-Z]{1}$", ErrorMessage = "Not a valid pan number")]
        public string panno { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        [Display(Name = "Address")]
        [DataType(DataType.Text)]
        public string address { get; set; }


        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Your email address is not in a valid format. Example of correct format: deepak.dubey1802@gmail.com")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email ID")]
        public string email { get; set; }


        [Required(ErrorMessage = "Enter Valid Password")]
        [Display(Name = "Password")]
        [StringLength(13, MinimumLength = 10)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Mobile number")]
        public string password { get; set; }
    }
}


