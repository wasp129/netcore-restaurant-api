using System.Collections.Generic;
using SundownBoulevard.Models.Reservation;

namespace SundownBoulevard.Dtos.User
{
    public class UserReadDto
    {
        public string Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }
        
        public virtual ICollection<ReservationModel> Reservations { get; set; }
    }
}