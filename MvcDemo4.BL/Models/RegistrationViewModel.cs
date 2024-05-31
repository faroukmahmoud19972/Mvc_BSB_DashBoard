using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemo4.BL.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage ="This Field Is Required")]

        [EmailAddress(ErrorMessage ="InValid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]

        [MinLength(6,ErrorMessage ="Min Password lenght is 6")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]

        [MinLength(6, ErrorMessage = "Min Password lenght is 6")]

        [Compare("Password", ErrorMessage = "Passwords should be the same.")]
        public string ConfirmPassowrd { get; set; }
        public bool IsAgree { get; set; }
    }
}
