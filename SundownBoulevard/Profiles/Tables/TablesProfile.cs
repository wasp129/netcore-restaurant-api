using AutoMapper;
using SundownBoulevard.Dtos.Table;
using SundownBoulevard.Models.Table;

namespace SundownBoulevard.Profiles.Tables
{
    public class TablesProfile : Profile
    {
        public TablesProfile()
        {
            CreateMap<TableModel, TableReadDto>();
        }
    }
}