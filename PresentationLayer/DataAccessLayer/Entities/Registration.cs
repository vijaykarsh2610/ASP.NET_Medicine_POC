using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Registration
    {
        [Key] // This marks 'Id' as the primary key
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your First Name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your Email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Contact No.")]
        [MinLength(10, ErrorMessage = "Contact No must be at least 10 characters long.")]
        public string ContactNo { get; set; }

        //[Required(ErrorMessage = "Please enter your Password.")]
        //[MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Please confirm your Password.")]
        //[Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ForgotPassword { get; set; }

        // Add other properties as needed
    }

}

