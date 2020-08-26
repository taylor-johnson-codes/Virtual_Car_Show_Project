using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Virtual_Car_Show_Project.Models
{
    [NotMapped]
    public class LoginReg
    {
        [Required]
        public string Email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}
    }
}