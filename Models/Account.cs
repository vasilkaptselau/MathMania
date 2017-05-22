using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathMania.Models
{
    public class Account
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter the Students first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Please enter the Students last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please create a Login for the student.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }





}