using AutoMapper;
using bank.Models;
using Microsoft.AspNetCore.Mvc;
using Solid.Core.DTOs;
using Solid.Core.Enteties;
using Solid.Core.Services;
using Solid.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Officials : ControllerBase
    {
        private readonly IOfficialsServices _officialsService;
        private readonly IMapper _mapper;
        public Officials(IOfficialsServices officialsService,IMapper mapper)
        {
            _officialsService = officialsService;
            _mapper = mapper;
        }
        // GET: api/<Officials>
        [HttpGet]
        public ActionResult Get()
        {
            var officials = _officialsService.GetOfficials();
            var officialsDto = new List<OffiicalDto>();
            for (int i = 0; i < officials.LongCount(); i++)
            {
                officialsDto.Add(_mapper.Map<OffiicalDto>(officials[i]));
            }
            return Ok(officialsDto);
        }

        // GET api/<Officials>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var officialsDto = _mapper.Map<OffiicalDto>(_officialsService.GetById(id));
            return Ok(officialsDto);
        }

        // POST api/<Officials>
        [HttpPost]
        public void Post([FromBody] OfficialPostModel value)
        {
            var officialToAdd = new Official { Name=value.Name };

            _officialsService.AddOfficial(officialToAdd);

        }

        // PUT api/<Officials>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OfficialPostModel value)
        {
            var officialToUpdate = new Official { Name = value.Name };
            _officialsService.UpdateOfficial(id, officialToUpdate);
        }

        // DELETE api/<Officials>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _officialsService.DeleteOfficial(id);
            return NoContent();
        }
    }
}
