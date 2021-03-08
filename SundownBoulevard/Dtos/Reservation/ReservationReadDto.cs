using System;
using SundownBoulevard.Models.User;

namespace SundownBoulevard.Dtos.Reservation
{
    public class ReservationReadDto
    {
        public string Id { get; set; }
        
        public string SelectedMeal { get; set; }
        
        public string SelectedDrink { get; set; }
        
        public int NoOfPeople { get; set; }
        
        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }

        public virtual UserModel User { get; set; }
    }
}