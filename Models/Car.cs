using System;
using System.ComponentModel.DataAnnotations;

namespace Virtual_Car_Show_Project.Models
{
    public class Car
    {
        [Key]
        public int CarId {get;set;}

        [Required]
        public int Year {get;set;}

        [Required]
        public string Make {get;set;}

        [Required]
        public string Model {get;set;}

        [Required]
        public string Category {get;set;}

        [Required]
        public string Description {get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int UserId {get;set;}  // Foreign Key

        public User Submittor {get;set;}  // Navigation Property
    }
}