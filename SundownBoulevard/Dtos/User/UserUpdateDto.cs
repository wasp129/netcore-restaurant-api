using System.ComponentModel.DataAnnotations;

namespace SundownBoulevard.Dtos.User
{
    public class UserUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [Required]
        [MaxLength(11)]
        public string Phone { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}