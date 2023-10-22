using IRDbApi.Models;

namespace IRDbApi.Repositories
{
    public class MovieRepository : IRepository<MovieModel>
    {
        private readonly AppDbContext _dbContext;
 
        public MovieRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(MovieModel movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            MovieModel? movie = _dbContext.Movies.Find(id);

            if(movie != null)
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<MovieModel> GetAll()
        {
            return _dbContext.Movies;
        }

        public MovieModel? GetById(int id)
        {
            return _dbContext.Movies.Find(id);
        }

        public void UpdateById(int id, MovieModel movie)
        {
            MovieModel? movieToUpdate = _dbContext.Movies.Find(id);

            if(movieToUpdate != null)
            {
                movieToUpdate.Director = movie.Director;
                movieToUpdate.Title = movie.Title;
                movieToUpdate.Duration = movie.Duration;
                movieToUpdate.Rating = movie.Rating;
                movieToUpdate.Genre = movie.Genre;
                movieToUpdate.Year = movie.Year;

                _dbContext.SaveChanges();
            }
        }
    }
}
