using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Interface;
using DataAccessLibrary.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IServices
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDBContext context;

        public MovieRepository(AppDBContext context)
        {
            this.context = context;
        }
        
        public void Add(Movie movie)
        {
            context.movies.Add(movie);
            context.SaveChanges();
        }

        public IEnumerable<Movie> DeletedMovies()
        {
            return context.movies.Where(x => x.IsDeleted.Equals(true));
        }

        public void Delete(Movie movie)
        {
            movie.IsDeleted = true;
            movie.Date_Deleted = DateTime.Now;
            context.Entry(movie).State = EntityState.Modified;
            context.SaveChanges();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await context.movies.FirstAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
             return await context.movies.Where(x => x.IsDeleted.Equals(false)).ToListAsync();
        }
     

        public void Update(Movie movie)
        {
            context.Entry(movie).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}
