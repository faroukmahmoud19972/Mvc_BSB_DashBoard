using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MvcDemo4.DAL.Extend
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        public bool IsAgree { get; set; }
    }
}
