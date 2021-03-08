using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SundownBoulevard.Models.Reservation;

namespace SundownBoulevard.Data.Reservation
{
    public class SqlReservationRepo : IReservationRepo
    {
        private readonly SundownBoulevardContext _context;

        public SqlReservationRepo(SundownBoulevardContext context)
        {
            _context = context;
        }
        public IEnumerable<ReservationModel> GetReservations()
        {
            return _context.Reservations.ToList();
            
        }

        public async Task<ReservationModel> CreateReservation(ReservationModel reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            else
            {
                // 10 tables with 2 seats each
                var totalCapacity = 20;
                var takenSeatsAtGivenTime = _context.Reservations
                    .Where(r => reservation.Start >= r.Start && reservation.Start <= r.End)
                    .Where(r => reservation.End >= r.Start && reservation.End <= r.End)
                    .Sum(r => r.NoOfPeople);
                
                var capacityAtGivenTime = totalCapacity - takenSeatsAtGivenTime;

                if (capacityAtGivenTime / reservation.NoOfPeople >= 1)
                {
                    _context.Reservations.Add(reservation);
                    await _context.SaveChangesAsync();
                    reservation = await _context.Reservations
                        .Include(r => r.User)
                        .FirstAsync(r => r.User.Id == reservation.UserId);
                
                    return reservation;
                }
                else
                {
                    return null;
                }
            }
        }
        
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}