using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MathMania.Models
{
    public class RegisterVm
    {
        [Key]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [MaxLength(8)]
        public string Password { get; set;}

        [Required]
        [Display(Name = "Confirm Password")]
        [MaxLength(8)]
        public string ConfirmPassword { get; set; }
    }




}