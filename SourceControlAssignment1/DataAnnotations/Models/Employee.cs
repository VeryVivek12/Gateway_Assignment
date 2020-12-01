using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAnnotations.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Employee Name is Required")]
        [StringLength(35), MinLength(4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address Required")]
        [StringLength(300)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Salary Required")]
        [Range(3000, 100000, ErrorMessage = "Must be within 3000 and 100000")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        [MaxLength(50)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Enter Valid Email")]
        public string Email { get; set; }

    }
}