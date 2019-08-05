using System;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    public class Customer
    {
        public bool IsSubscribedToNewsLetter { get; set; }

        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
