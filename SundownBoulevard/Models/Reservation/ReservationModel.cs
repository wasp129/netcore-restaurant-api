using System;
using System.ComponentModel.DataAnnotations;
using SundownBoulevard.Models.User;

namespace SundownBoulevard.Models.Reservation
{
    public class ReservationModel
    {
        [Key]
         public string Id { get; set; }
         
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
         
         [Required]
         public virtual UserModel User { get; set; }
    }
}