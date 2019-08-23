using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.Areas.AppData;
using Vidly.Areas.Dtos;
using Vidly.Models;
using Microsoft.EntityFrameworkCore;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private ApplicationDataDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(IMapper mapper)
        {
            _context = new ApplicationDataDbContext();
            _mapper = mapper;
        }

        // GET: api/movies
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(_mapper.Map<Movie, MovieDto>);
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(_mapper.Map<Movie, MovieDto>(movie));
        }

        // POST api/movies
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateMovie(MovieDto movieDto)
        {
            var movie = _mapper.Map<MovieDto, Movie>(movieDto);

            _context.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.Path + movie.Id, UriKind.Relative), movieDto);
        }

        // PUT api/movies/5
        [HttpPut("{id}")]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new ArgumentException("Movie is not found.");

            _mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
