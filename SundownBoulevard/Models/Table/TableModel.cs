using System.ComponentModel.DataAnnotations;
using SundownBoulevard.Models.Reservation;

namespace SundownBoulevard.Models.Table
{
    public class TableModel
    {
        [Key]
        public string Id { get; set; }
        
        [Required]
        public string Capacity { get; set; }
        
        [Required]
        public virtual ReservationModel Reservation { get; set; }
    }
}