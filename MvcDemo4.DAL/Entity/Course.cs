using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemo4.DAL.Entity
{
    public class Course
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        
    }
}
