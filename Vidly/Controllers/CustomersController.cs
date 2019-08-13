using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList<MembershipType>();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                    {
                       Customer = customer,
                       MembershipTypes = _context.MembershipTypes.ToList()
                    };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
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

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) throw new ArgumentException("This page is not found.");

            var viewmodel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewmodel);
        }
    }
}
