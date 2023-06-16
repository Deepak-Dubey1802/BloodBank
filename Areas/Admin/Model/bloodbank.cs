using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBankManagementSystem.Areas.Admin.Model
{
    public class bloodbank
    {
    

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
        public int bloodgroup { get; set; }




        [Display(Name = "City")]
        public int cityname { get; set; }



        [Display(Name = "State")]
        public int statename { get; set; }


        [Display(Name = "Country")]
        public int countryname { get; set; }

        

       

    }
}