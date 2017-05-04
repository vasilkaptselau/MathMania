using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MathMania.Models
{
    public class RegisterVm
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter the Students first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Please enter the Students last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please create a Login for the student.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        //[Key]
        //[Display(Name = "UserName")]
        //public string UserName { get; set; }

        //[Required]
        //[Display(Name = "Password")]
        //[MaxLength(8)]
        //public string Password { get; set;}

        //[Required]
        //[Display(Name = "Confirm Password")]
        //[MaxLength(8)]
        //public string ConfirmPassword { get; set; }
    }




}