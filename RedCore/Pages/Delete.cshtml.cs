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

namespace RedCore.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IMovieRepository movieRepository;

        public DeleteModel(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id > 0)
            {
                Movie = await movieRepository.GetByIdAsync(id);

                if (Movie == null)
                {
                    return NotFound();
                }
                return Page();
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id > 0) { 

            Movie = await movieRepository.GetByIdAsync(id);

            if (Movie != null)
            {
                movieRepository.Delete(Movie);
            }

            return RedirectToPage("./Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
