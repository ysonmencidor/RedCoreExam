using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Model;
using DataAccessLibrary.Interface;
using Microsoft.AspNetCore.Http;

namespace RedCore.Pages
{

    public class IndexModel : PageModel
    {
        private readonly IMovieRepository movieRepository;

        public IndexModel(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public IEnumerable<Movie> Movie { get;set; }

        public bool IsAuthenticated = false;

        [BindProperty]
        public Movie movie { get; set; }

        public async Task OnGetAsync()
        {
            if(HttpContext.Session.GetString("username") != null)
            {
                IsAuthenticated = true;
            }
            Movie = await movieRepository.GetMoviesAsync();
        }


        public async Task<PartialViewResult> OnGetMoviePartial(int id)
        {
            if (id > 0)
            {
                movie = await movieRepository.GetByIdAsync(id);
                return Partial("_AddEditPartial", movie);
            }
            else
            {
                var model = new Movie();
                return Partial("_AddEditPartial", model);
            }
        }

        public JsonResult OnPostSaveData(Movie movie)
        {
            if (movie.RentDate != null)
            {
                movie.IsRented = true;
            }
            else
            {
                movie.IsRented = false;
            }
        
            if (movie.Id == 0)
            {
                movieRepository.Add(movie);
                return new JsonResult(new { success = true, message = "Save Successfully" });
            }
            else
            {
                movieRepository.Update(movie);
                return new JsonResult(new { success = true, message = "Update Successfully" });
            }
        }


        public async Task<JsonResult> OnPostDeleteMovie(int movieId)
        {
            if (movieId > 0)
            {
                Movie model = await movieRepository.GetByIdAsync(movieId);
                movieRepository.Delete(model);
                return new JsonResult(new { success = true, message = "Delete Successfully" });
            }
            else
            {
                return new JsonResult(new { success = false, message = "Movie cannot be found!" });
            }
        }


    }
}
