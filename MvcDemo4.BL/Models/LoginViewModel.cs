using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemo4.BL.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="This Field is required ")]

        [EmailAddress(ErrorMessage ="In Valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field is required ")]

        [MinLength(6,ErrorMessage ="Min lenght for password is 6 char")]

        public string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }

    }
}
