using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SundownBoulevard.Data.Reservation;
using AutoMapper;
using SundownBoulevard.Dtos.Reservation;
using SundownBoulevard.Models.Reservation;

namespace SundownBoulevard.Controllers.Reservation
{
    [Route("api")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepo _repository;
        private readonly IMapper _mapper;

        public ReservationController(IReservationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //GET api/reservations
        [HttpGet("reservations", Name="GetAllReservations")]
        public ActionResult<IEnumerable<ReservationReadDto>> GetAllReservations()
        {
            var reservations = _repository.GetReservations();
            return Ok(_mapper.Map<IEnumerable<ReservationReadDto>>(reservations));
        }
        
        //POST api/reservations
        [HttpPost("reservations")]
        public async Task<ActionResult<ReservationReadDto>> CreateReservation(ReservationCreateDto reservationCreateDto)
        {
            var reservationModel = _mapper.Map<ReservationModel>(reservationCreateDto);
            var x = await _repository.CreateReservation(reservationModel);
            var reservationReadDto = _mapper.Map<ReservationReadDto>(x);

            if (x != null)
            {
                return CreatedAtRoute(nameof(GetAllReservations), new {Id = x.Id}, reservationReadDto);
            }
            else
            {
                return NoContent();
            }
        }
    }
}