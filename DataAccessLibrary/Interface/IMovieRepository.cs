using DataAccessLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interface
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        IEnumerable<Movie> DeletedMovies();
        Task<Movie> GetByIdAsync(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(Movie movie);
    }
}
