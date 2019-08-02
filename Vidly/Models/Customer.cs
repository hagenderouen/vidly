using System;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
