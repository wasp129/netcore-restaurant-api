using System.Collections.Generic;
using SundownBoulevard.Models.Table;

namespace SundownBoulevard.Data.Table
{
    public interface ITableRepo
    {
        IEnumerable<TableModel> GetTables();
        IEnumerable<TableModel> GetAvailableTables(string reqStartTime);
    }
}