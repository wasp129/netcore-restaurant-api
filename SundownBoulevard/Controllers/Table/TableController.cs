using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SundownBoulevard.Data.Table;
using SundownBoulevard.Dtos.Table;

namespace SundownBoulevard.Controllers.Table
{
    [Route("api")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableRepo _repository;
        private readonly IMapper _mapper;

        public TableController(ITableRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //GET api/tables
        [HttpGet("tables")]
        public ActionResult<IEnumerable<TableReadDto>> GetAllTables()
        {
            var tables = _repository.GetTables();
            return Ok(_mapper.Map<IEnumerable<TableReadDto>>(tables));
        }
        
        //GET api/tables
        [HttpGet("tables/{reqStartTime}")]
        public ActionResult<IEnumerable<TableReadDto>> GetAvailableTables(string reqStartTime)
        {
            var availableTables = _repository.GetAvailableTables(reqStartTime);
            return Ok(_mapper.Map<IEnumerable<TableReadDto>>(availableTables));
        }
    }
}