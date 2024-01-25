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
        public ActionResult Get()
        {
            var customersDto = _mapper.Map<CustomerDto>(_customerService.GetCustomers());
            return Ok(customersDto);
        }

        // GET api/<Customers>/5
        [HttpGet("{tz}")]
        public ActionResult Get(string tz)
        {
            var customersDto = _mapper.Map<CustomerDto>(_customerService.GetByTz(tz));
            return Ok(customersDto);
        }

        // POST api/<Customers>
        [HttpPost]
        public ActionResult Post([FromBody] CustomerPostModel value)
        {
            var customerToAdd = new Customer { Tz=value.Tz,Name=value.Name};

            _customerService.AddCustomer(customerToAdd);
            return NoContent();
        }

        // PUT api/<Customers>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CustomerPostModel value)
        {
            var customerToAdd = new Customer { Tz = value.Tz, Name = value.Name };

            _customerService.UpdateCustomer(id, customerToAdd);
            return NoContent();
        }

        // DELETE api/<Customers>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}
