using System;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
