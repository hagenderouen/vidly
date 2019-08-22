using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Areas.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "{0} must be between {1} and {2}")]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }
    }
}
