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
    public class SignupModel : PageModel
    {
        public SignupModel(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public string Message;

        [BindProperty]
        public InputModel Input { get; set; }

        public IUserRepository UserRepository { get; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.EmailAddress, ErrorMessage = "Please Input a Valid Email Address")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Name is Required")]
            public string FullName { get; set; }

            [Required]
            [StringLength(20, ErrorMessage = "The Password should not exceed more than 20 characters.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            var User = new User();
            User.Email = Input.Email;
            User.Password = Input.Password;
            User.FullName = Input.FullName;

            if (UserRepository.EmailAvail(Input.Email))
            {
                UserRepository.Create(User);
                Message = "Register successfully!";
                return Page();
            }
            else
            {
                Message = "This email is already registered!";
                return Page();
            }
        }
    }
}