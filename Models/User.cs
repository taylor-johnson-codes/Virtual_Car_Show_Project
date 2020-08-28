using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Virtual_Car_Show_Project.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "is required")]
        [MaxLength(30, ErrorMessage = "can't be more than 30 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "is required")]
        [MaxLength(30, ErrorMessage = "can't be more than 30 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "is required")]
        [MaxLength(30, ErrorMessage = "can't be more than 30 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "is required")]
        [MaxLength(2, ErrorMessage = "can't be more than 2 characters; i.e. Washington should be WA")]
        public string State { get; set; }

        [Required(ErrorMessage = "is required")]
        [MaxLength(45, ErrorMessage = "can't be more than 45 characters")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "is required")]
        [MinLength(8, ErrorMessage = "must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        [Required(ErrorMessage = "is required")]
        [Compare("Password", ErrorMessage="passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")] 
        public string Confirm { get; set; }

        public List<Car> RegisteredCars { get; set; }  // Navigation Property
        public List<CarShow> CarShowsCreated { get; set; }
    }
}