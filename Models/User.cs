using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Virtual_Car_Show_Project.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required]
        public string Name {get;set;}

        [Required]
        public string City {get;set;}

        [Required]
        public string State {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        public string Confirm {get;set;}

        public List<Car> SubmittedCars {get;set;}  // Navigation Property
    }
}