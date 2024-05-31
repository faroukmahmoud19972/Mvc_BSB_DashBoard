using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemo4.DAL.Entity
{
    [Table("Department")]
    public class Department
    {
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]

        [MaxLength(255)]
        public string Name { get; set; }=string.Empty;
        [Required]

        [MaxLength(255)]

        public string Code { get; set; }=string.Empty;

        public ICollection<Employee> Employee { get; set; }

    }
}
