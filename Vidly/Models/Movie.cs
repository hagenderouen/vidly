using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ReleaseDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }
    }
}
