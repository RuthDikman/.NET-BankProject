using AutoMapper;
using bank.Models;
using Microsoft.AspNetCore.Mvc;
using Solid.Core.DTOs;
using Solid.Core.Enteties;
using Solid.Core.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customers : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public Customers(ICustomerService customerService,IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        // GET: api/<Customers>
        [HttpGet]
        public async Task<ActionResult>  Get()
        {
            var customers =await _customerService.GetCustomersAsync();
            var customersDto = new List<CustomerDto>();
            for (int i = 0; i < customers.LongCount(); i++)
            {
                customersDto.Add(_mapper.Map<CustomerDto>(customers[i]));
            }
            return Ok(customersDto);
        }

        // GET api/<Customers>/5
        [HttpGet("{tz}")]
        public async Task<ActionResult>  Get(string tz)
        {
            var customersDto = _mapper.Map<CustomerDto>(await _customerService.GetByTzAsync(tz));
            return Ok(customersDto);
        }

        // POST api/<Customers>
        [HttpPost]
        public async Task<ActionResult>  Post([FromBody] CustomerPostModel value)
        {
            var customerToAdd = new Customer { Tz=value.Tz,Name=value.Name};

            await _customerService.AddCustomerAsync(customerToAdd);
            return NoContent();
        }

        // PUT api/<Customers>/5
        [HttpPut("{id}")]
        public async Task<ActionResult>  Put(int id, [FromBody] CustomerPostModel value)
        {
            var customerToAdd = new Customer { Tz = value.Tz, Name = value.Name };

           await _customerService.UpdateCustomerAsync(id, customerToAdd);
            return NoContent();
        }

        // DELETE api/<Customers>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult>  Delete(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}
