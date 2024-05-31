using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemo4.BL.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "This Field Is Required")]

        [EmailAddress(ErrorMessage = "InValid Email Address")]
        public string Email { get; set; }
    }
}
