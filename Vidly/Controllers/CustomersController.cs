using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.Areas.Identity.Data;
using Vidly.Areas.AppData;
using Vidly.Models;
using Vidly.ViewModels;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDataDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDataDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: /Customers/
        public IActionResult Index()
        {
            var Customers = _context.Customers.Include(c => c.MembershipType).ToList<Customer>();

            return View(Customers);
        }

        // GET: /Customers/Details/
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new ArgumentException("The page is not found");

            return View(customer);
        }
    }
}
