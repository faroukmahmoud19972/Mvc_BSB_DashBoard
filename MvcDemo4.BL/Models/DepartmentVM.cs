using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemo4.BL.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        [StringLength(50,ErrorMessage ="Max lenght is 50 Character")]
        [MinLength(3, ErrorMessage = "Min lenght is 6 Character")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Code Is Required")]
        [StringLength(50, ErrorMessage = "Max lenght is 50 Character")]
        [MinLength(3, ErrorMessage = "Min lenght is 2 Character")]
        public string Code { get; set; }
    }
}
