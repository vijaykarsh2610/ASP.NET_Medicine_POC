using System.ComponentModel.DataAnnotations;
namespace DataAccessLayer.Domain
{
   
    public class Login
    {
        [Key] // This property is the primary key
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "IsAdmin is required.")]
        public bool IsAdmin { get; set; }
    }

}
