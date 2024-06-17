using Microsoft.AspNetCore.Mvc;
using veeb.models;
using System.Collections.Generic;
using System.Linq;

namespace veeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesContext _context;

        public MoviesController(MoviesContext context)
        {
            _context = context;
        }

        // GET https://localhost:4444/movies
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            return Ok(_context.Movies.ToList());
        }

        // DELETE https://localhost:4444/movies/delete/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult<List<Movie>> Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound("Movie not found");
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok(_context.Movies.ToList());
        }

        // POST https://localhost:4444/movies/add
        [HttpPost("add")]
        public ActionResult<List<Movie>> Add([FromBody] Movie newMovie)
        {
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            return Ok(_context.Movies.ToList());
        }
    }
}
