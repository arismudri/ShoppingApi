using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApi.ModelsView;
using ShoppingApi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ShoppingDBContext context;
        private readonly IMapper mapper;

        public CustomerController(ShoppingDBContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<IEnumerable<JoinCustomerDTO>> Get()
        {
            var entity = context.Customers.Include(a=> a.CustomerItems).ThenInclude(b => b.Item).ToList();

            if (entity == null)
            {
                return null;
            }

            var data = mapper.Map<List<JoinCustomerDTO>>(entity);
            return Ok( data );
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<JoinCustomerDTO> Get(int id)
        {            
            var entity = context.Customers.Include(a=> a.CustomerItems).ThenInclude(b => b.Item).SingleOrDefault(c => c.Id == id);
            
            if (entity == null)
            {
                return NotFound();
            }

            var data = mapper.Map<JoinCustomerDTO>(entity);

            return Ok( data );
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<CustomerDTO> Post([FromBody] Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();

            var data = mapper.Map<CustomerDTO>(customer);
            return Ok( data );
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult<CustomerDTO> Put(int id, [FromBody] Customer customer)
        {
            var entity = context.Customers.SingleOrDefault(c => c.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = customer.Name;
            entity.Age = customer.Age;

            context.Customers.Update(entity);

            context.SaveChanges();

            var data = mapper.Map<CustomerDTO>(entity);
            return Ok( data );
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult<CustomerDTO> Delete(int id)
        {
            var entity = context.Customers.SingleOrDefault(c => c.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            context.Customers.Remove(entity);
            context.SaveChanges();
            var data = mapper.Map<CustomerDTO>(entity);
            return Ok( data );
        }
    }
}
