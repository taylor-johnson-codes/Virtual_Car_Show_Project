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
        public string Year { get; set; }

        [Required(ErrorMessage = "is required")]
        public string Make { get; set; }

        [Required(ErrorMessage = "is required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "is required")]
        public string Category { get; set; }

        [MaxLength(100, ErrorMessage = "can't be more than 100 characters")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "is required")]
        public int UserId { get; set; }  // Foreign Key

        [Required(ErrorMessage = "is required")]
        [Display(Name = "Car Show to Attend")]
        public int CarShowId {get;set;}

        public User Registerer { get; set; }  // Navigation Property
        public CarShow CarShowToAttend { get; set; }  // Navigation Property
    }
}