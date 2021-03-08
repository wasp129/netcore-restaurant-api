using System;
using System.ComponentModel.DataAnnotations;
using SundownBoulevard.Models.User;

namespace SundownBoulevard.Dtos.Reservation
{
    public class ReservationCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string SelectedMeal { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string SelectedDrink { get; set; }
        
        [Required]
        public int NoOfPeople { get; set; }
        
        [Required]
        public DateTime Start { get; set; }
        
        [Required]
        public DateTime End { get; set; }
        
        public string UserId { get; set; }
    }
}