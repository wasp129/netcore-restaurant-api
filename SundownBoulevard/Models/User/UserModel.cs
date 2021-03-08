using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SundownBoulevard.Models.Reservation;

namespace SundownBoulevard.Models.User
{
    public class UserModel
    {
        [Key]
        public string Id { get; set; }
        
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
        
        public virtual ICollection<ReservationModel> Reservations { get; set; }
        
    }
}