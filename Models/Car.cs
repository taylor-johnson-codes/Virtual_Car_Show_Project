using System;
using System.ComponentModel.DataAnnotations;

namespace Virtual_Car_Show_Project.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required(ErrorMessage = "is required")]
        [MinLength(4, ErrorMessage = "must be 4 numbers in YYYY format")]
        [MaxLength(4, ErrorMessage = "must be 4 numbers in YYYY format")]
        public int Year { get; set; }

        [Required(ErrorMessage = "is required")]
        public string Make { get; set; }

        [Required(ErrorMessage = "is required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "is required")]
        [MaxLength(100, ErrorMessage = "can't be more than 100 characters")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }  // Foreign Key

        public User Submittor { get; set; }  // Navigation Property
    }
}