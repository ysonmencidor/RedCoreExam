using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibrary.Interface;
using DataAccessLibrary.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RedCore.Pages
{
    public class ArchivedModel : PageModel
    {
        private readonly IMovieRepository movieRepository;

        public ArchivedModel(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        
        public List<Movie> movies { get; set; }

        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("Index");
            }
            movies = movieRepository.DeletedMovies().ToList();
            return Page();
        }
    }
}