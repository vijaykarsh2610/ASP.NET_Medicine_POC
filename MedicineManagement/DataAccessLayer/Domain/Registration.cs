using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Domain
{
        public class Registration
        {
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
            public string Contact { get; set; }

            [Required(ErrorMessage = "Please enter your Password.")]
            [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
            public string Password { get; set; }

            
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; }

            public bool IsAdmin { get; set; }
        }


    
}
