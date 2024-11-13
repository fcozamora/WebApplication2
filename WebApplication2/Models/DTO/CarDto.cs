using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.DTO
{
    public class CarDto
    {
        public int CarID { get; set; }
        [Required(ErrorMessage = "The field Make is Required")]
        [MaxLength(50, ErrorMessage = "The field Make can't exceed")]
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
    }
}