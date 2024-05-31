using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemo4.DAL.Entity
{
    [Table("Employee")]
    public class Employee
    {
     
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]

        [MaxLength(255)]

        public double Salary { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActive{ get; set; }
        public string Notes { get; set; }

        public string  Email { get; set; }

        public string Address { get; set; }
        public int DepartmentId { get; set; }


        //[ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
