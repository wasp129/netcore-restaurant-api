using System.Collections.Generic;
using System.Threading.Tasks;
using SundownBoulevard.Models.Reservation;

namespace SundownBoulevard.Data.Reservation
{
    public interface IReservationRepo
    {
        bool SaveChanges();
        IEnumerable<ReservationModel> GetReservations();
        Task<ReservationModel> CreateReservation(ReservationModel reservation);
    }
}