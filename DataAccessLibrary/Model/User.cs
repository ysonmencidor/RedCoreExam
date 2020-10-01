using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLibrary.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Please Input a Valid Email Address")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "The Password should not exceed more than 20 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
