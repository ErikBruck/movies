using Microsoft.AspNetCore.Mvc;
using veeb.models;
using System.Collections.Generic;

namespace veeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> _movies = new()
        {
            new Movie(1, "Inception", 8.8, 2010, "https://image.url/inception.jpg"),
            new Movie(2, "The Matrix", 8.7, 1999, "https://image.url/matrix.jpg"),
            new Movie(3, "Interstellar", 8.6, 2014, "https://image.url/interstellar.jpg"),
            new Movie(4, "The Godfather", 9.2, 1972, "https://image.url/godfather.jpg"),
            new Movie(5, "Pulp Fiction", 8.9, 1994, "https://image.url/pulpfiction.jpg")
        };

        // GET https://localhost:4444/movies
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            return Ok(_movies);
        }

        // DELETE https://localhost:4444/movies/delete/{index}
        [HttpDelete("delete/{index}")]
        public ActionResult<List<Movie>> Delete(int index)
        {
            if (index < 0 || index >= _movies.Count)
            {
                return NotFound("Index out of range");
            }
            _movies.RemoveAt(index);
            return Ok(_movies);
        }

        // POST https://localhost:4444/movies/add
        [HttpPost("add")]
        public ActionResult<List<Movie>> Add([FromBody] Movie newMovie)
        {
            _movies.Add(newMovie);
            return Ok(_movies);
        }
    }
}
