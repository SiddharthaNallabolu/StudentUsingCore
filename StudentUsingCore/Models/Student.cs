using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUsingCore.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string RollNumber { get; set; }
        [Range(1,12,ErrorMessage ="Studing Class need to be in between 1 and 12")]
        public int ClassStudying { get; set; }
        public string ImageUrl { get; set; }

    }
}
