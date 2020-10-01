using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibrary.Interface;
using DataAccessLibrary.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RedCore.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository userRepository;

        public LoginModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
        [TempData]
        public string Message { get; set; }

        public IActionResult OnGetLogOut()
        {
            HttpContext.Session.Remove("username");
            return RedirectToPage("Index");
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            var LoggedInUser = userRepository.Login(Input.Email,Input.Password);
            if(LoggedInUser == null)
            {
                Message = "Cannot Find User Account";
                return Page();
            }
            else
            {
                 HttpContext.Session.SetString("username", Input.Email);
                return RedirectToPage("Index");
            }
        }

    }
}