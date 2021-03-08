using AutoMapper;
using SundownBoulevard.Dtos.Reservation;
using SundownBoulevard.Models.Reservation;

namespace SundownBoulevard.Profiles.Reservations
{
    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {
            CreateMap<ReservationModel, ReservationReadDto>();
            CreateMap<ReservationCreateDto, ReservationModel>();
        }
    }
}