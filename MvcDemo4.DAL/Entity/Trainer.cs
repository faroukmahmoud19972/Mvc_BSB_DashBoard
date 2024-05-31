using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemo4.DAL.Entity
{
    public class Trainer
    {
      
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required, EmailAddress]

        public string Email { get; set; }
        [Required, MaxLength(255)]
        public string Website { get; set; }
        public DateTime HireDate { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set;}
        public ICollection<Course> Course { get; set; }

    }
}
