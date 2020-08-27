using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Virtual_Car_Show_Project.Models
{
    public class CarShow
    {
        [Key]
        public int CarShowId { get; set; }

        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [MaxLength(30, ErrorMessage = "can't be more than 30 characters")]
        [Display(Name = "Car Show Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [MaxLength(30, ErrorMessage = "can't be more than 30 characters")]
        [Display(Name = "Car Club Name")]
        public string ClubName { get; set; }

        [Required]
        [Display(Name = "Start Date and Time")]
        public DateTime StartDateAndTime { get; set; }

        [Required]
        [Display(Name = "End Date and Time")]
        public DateTime EndDateAndTime { get; set; }

        [Required(ErrorMessage = "is required")]
        [MaxLength(30, ErrorMessage = "can't be more than 30 characters")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "is required")]
        [MaxLength(30, ErrorMessage = "can't be more than 30 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "is required")]
        [MaxLength(2, ErrorMessage = "can't be more than 2 characters; i.e. Washington should be WA")]
        public string State { get; set; }

        [Required(ErrorMessage = "is required")]
        [MinLength(5, ErrorMessage = "can only be 5 numbers")]
        [MaxLength(5, ErrorMessage = "can only be 5 numbers")]
        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [MaxLength(100, ErrorMessage = "can't be more than 100 characters")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }  // Foreign Key

        public User CarShowCreator { get; set; }  // Navigation Property
        public List<Car> RegisteredCars { get; set; }  // Navigation Property
    }
}