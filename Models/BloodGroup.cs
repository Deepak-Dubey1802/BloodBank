using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBankManagementSystem.Models
{
    public class BloodGroup
    {
        public int bloodgroupid { get; set; }
        [Display(Name = "Blood Group")]
        public string bloodgroup { get; set; }
    }
}