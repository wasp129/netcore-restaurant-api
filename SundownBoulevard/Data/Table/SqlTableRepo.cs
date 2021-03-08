using System;
using System.Collections.Generic;
using System.Linq;
using SundownBoulevard.Models.Table;

namespace SundownBoulevard.Data.Table
{
    public class SqlTableRepo : ITableRepo
    {
        private readonly SundownBoulevardContext _context;

        public SqlTableRepo(SundownBoulevardContext context)
        {
            _context = context;
        }

        public IEnumerable<TableModel> GetTables()
        {
            return _context.Tables.ToList();
        }

        public IEnumerable<TableModel> GetAvailableTables(string reqStartTime)
        {
            var parsedStartTime = DateTime.Parse(reqStartTime);
            var parsedEndTime = parsedStartTime.AddHours(2);
            
            var filteredTables = _context.Tables
                .Where(t => 
                    (parsedStartTime < t.Reservation.Start || parsedStartTime > t.Reservation.End) &&
                    (parsedEndTime < t.Reservation.Start || parsedEndTime > t.Reservation.End) ||
                    t.Reservation == null
                );

            return filteredTables.ToList();
        }
    }
}