using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Employee_Details.Models
{
    public class EmployeeModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        
        [Required]
        public string Gender { get; set; }
        
        [DataType(DataType.Date)]
        [Required (ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        
        [Column(TypeName ="file")]
        public byte[] Photo { get; set; }

    }
}