using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.Areas.Identity.Data;
using Vidly.Models;
using Vidly.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: /Customers/
        public IActionResult Index()
        {
            var Customers = GetCustomers();

            return View(Customers);
        }

        // GET: /Customers/Details/
        public IActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new ArgumentException("The page is not found");

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Name = "John Smith", Id = 1 },
                new Customer {Name = "Mary Contrary", Id = 2 }
            };
        }
    }
}
