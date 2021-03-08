using System.ComponentModel.DataAnnotations;
using SundownBoulevard.Models.Reservation;

namespace SundownBoulevard.Dtos.Table
{
    public class TableReadDto
    {
        [Key]
        public string Id { get; set; }
        
        [Required]
        public string Capacity { get; set; }
        
        [Required]
        public virtual ReservationModel Reservation { get; set; }
    }
}