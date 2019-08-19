using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.Areas.AppData;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Vidly.Areas.Dtos;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private ApplicationDataDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(IMapper mapper)
        {
            _context = new ApplicationDataDbContext();
            _mapper = mapper;
        }

        // GET: api/customers
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(_mapper.Map<Customer, CustomerDto>);
        }

        // GET: api/customers/1
        [HttpGet("{id}")]
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);


            if (customer == null)
                throw new ArgumentException("The customer is not found.");

            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        // POST api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
        }

        // PUT api/customers/1
        [HttpPut("{id}")]
        public void UpDateCustomer(int id, CustomerDto customerDto)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new ArgumentException("This Customer is not found.");

            _mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
        }

        // DELETE api/customers/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
