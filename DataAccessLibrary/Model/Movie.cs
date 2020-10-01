using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLibrary.Model
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Title should not exceed more than 50 characters.")]
        [Required(ErrorMessage = "Title is Required.")]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsRented { get; set; }

        public DateTime? RentDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime? Date_Deleted { get; set; }

        public Movie()
        {
            if(RentDate == null)
            {
                IsRented = false;
            }
            else
            {
                IsRented = true;
            }
        }
    }
}
