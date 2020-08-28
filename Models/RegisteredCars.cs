using System;
using System.ComponentModel.DataAnnotations;

namespace Virtual_Car_Show_Project.Models
{
    public class RegisteredCars
    {
        [Key]
        public int RegisteredCarsId { get; set; }

        // Foreign Keys:
        public int UserId { get; set; }
        public int CarShowId { get; set; }
        public int CarId { get; set; }

        // Navigation Properties:
        public User CarOwner { get; set; }
        public CarShow CarShowToAttend { get; set; }
        public Car CarOwned { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}