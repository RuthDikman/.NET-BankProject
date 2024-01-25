using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solid.Core.Enteties;
using Solid.Core.Services;
using Solid.Core.DTOs;
using bank.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BunkTurns : ControllerBase
    {
        private readonly ITurnsServices _turnsServices;
        private readonly IMapper _mapper;
        public BunkTurns(ITurnsServices turnsServices,IMapper mapper)
        {
            _turnsServices = turnsServices;
            _mapper = mapper;
        }

        // GET: api/<BunkTurns>
        [HttpGet]
        public ActionResult Get()
        {
            var turns = _turnsServices.GetTurns();
            var turnsDto=new List<TurnDto>();
            for (int i = 0;i<turns.LongCount() ; i++)
            {
                turnsDto.Add(_mapper.Map<TurnDto>(turns[i]));
            }   
          return Ok(turnsDto);
        }

        // GET api/<BunkTurns>/5
        [HttpGet("{start}")]
        public ActionResult Get(DateTime start)
        {
            var turnsDto = _mapper.Map<TurnDto>(_turnsServices.GetByStart(start));
            return Ok(turnsDto);
        }

        // POST api/<BunkTurns>
        [HttpPost]
        public void Post([FromBody] TurnPostModel value)
        {
            var turnToAdd = new Turn { Start = value.Start, OfficialId = value.OfficialId, CustomerId = value.CustomerId };
            _turnsServices.AddTurn(turnToAdd);
        }

        // PUT api/<BunkTurns>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TurnPostModel value)
        {
            var turnToUpdate = new Turn { Start = value.Start, OfficialId = value.OfficialId, CustomerId = value.CustomerId };
            _turnsServices.UpdateTurn(id, turnToUpdate);
        }

        // DELETE api/<BunkTurns>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           _turnsServices.DeleteTurn(id);
        }
    }
}
