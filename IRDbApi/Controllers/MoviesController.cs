using IRDbApi.Models;
using IRDbApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IRDbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository<MovieModel> _movieRepo;
        public MoviesController(IRepository<MovieModel> movieRepo)
        {
            _movieRepo = movieRepo;
        }

        [HttpGet]
        public ActionResult<List<MovieModel>> GetMovies()
        {
            return _movieRepo.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<MovieModel?> GetMovie(int id)
        {
            return _movieRepo.GetById(id);
        }

        [HttpPost]
        public void PostMovie([FromBody] MovieModel movie)
        {
            _movieRepo.Add(movie);
        }

        [HttpPut("{id}")]
        public void PutMovie(int id, [FromBody] MovieModel movie)
        {
            _movieRepo.UpdateById(id, movie);
        }

        [HttpDelete("{id}")]
        public void DeleteMovie(int id)
        {
            _movieRepo.DeleteById(id);
        }
    }
}
