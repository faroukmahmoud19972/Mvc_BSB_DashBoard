using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemo4.BL.Models
{
    public class TrainerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [StringLength(50, ErrorMessage = "Max Len 50")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Mail Invalid")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Website is Required")]
        [StringLength(50, ErrorMessage = "Max Len 50")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        public string Website { get; set; }
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Description Required")]
        [StringLength(2500, ErrorMessage = "Max Len 2500")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        public string Description { get; set; }
    }
}
