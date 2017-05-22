using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathMania.Models
{
    public class LoginVm
    {

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Your user name, please")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Use abc or ABC")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [RegularExpression("[0-9]", ErrorMessage = "Type ONLY six numbers")]
        [Display(Name = "Password")]
        [MaxLength(6)]
        public string Password { get; set; }

    }
}

    
