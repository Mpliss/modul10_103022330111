using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using modul10_103022330111;

namespace modul10_103022330111.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        public static List<Movie> daftarMovie = new List<Movie>()
        {
            new Movie {
                Title = "The Showhank Redemption",
                Director = "Frank Darabont",
                Stars = ["Tim Rabbins", "Morgon Freemon", "Bob Gunton", "William Sadler"],
                Description = "Two Imprisoned men bond over a number of years, finding salase and eventual redemption through acts of comon decency"
            },
            new Movie {
                Title = "The Godfather",
                Director = "Francis Ford Cappolo",
                Stars = ["Marlon Brando", "Al Pacino", "James Caan", "Diane Keaton"],
                Description = "The aging patriarch of an arganized crime dynasty in postwar New York City transfer control of his clandestine empire to his reluctant youngest son"
            },
            new Movie {
                Title = "The Drak Knight",
                Director = "Christopher Nolan",
                Stars = ["Christian Bale", "Heath Ledger", "Aaron Eckhart"],
                Description = "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness."
            }

        };
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAllMovie()
        {
            return Ok(daftarMovie);
        }
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieByIndex(int id)
        {
            if (id < 0 || id >= daftarMovie.Count)
            {
                return NotFound(new { message = "Movie tidak ditemukan" });
            }
            return Ok(daftarMovie[id]);
        }
        [HttpPost]
        public ActionResult AddMovie([FromBody] Movie mhsBaru)
        {
            daftarMovie.Add(mhsBaru);
            return Ok(new { message = "Movie telah ditambahkan", id = daftarMovie.Count - 1 });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            if (id < 0 || id >= daftarMovie.Count)
            {
                return NotFound(new { message = "Movie tidak ditemukan" });
            }
            daftarMovie.RemoveAt(id);
            return Ok(new { message = "Movie berhasi dihapus" });
        }
    }
}