using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.Models
{
    public class UserSignup
    {
        [Required(ErrorMessage = "Please Enter Your First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Please Enter A Valid Username")]
        //[Display(Name = "Username")]
        //public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter A Valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter A Strong Password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password Does not Match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Confirm Your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
