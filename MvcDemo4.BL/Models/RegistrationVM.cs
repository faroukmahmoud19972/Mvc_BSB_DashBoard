using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDemo4.BL.Models
{
    public class RegistrationVM
    {
        [Required(ErrorMessage ="This field is required")]

        [EmailAddress(ErrorMessage ="InValid Mail Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]

        [MinLength(5, ErrorMessage ="Min Len is 6")]

        [RegularExpression("[a-z]{1}[0-9]{5,8}")]
      
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]

        [MinLength(5, ErrorMessage = "Min Len is 6")]

        [Compare("Password" , ErrorMessage ="Not Match Password")]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }
    }
}
