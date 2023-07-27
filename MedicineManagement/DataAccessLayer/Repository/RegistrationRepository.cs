using DataAccessLayer.Data;
using DataAccessLayer.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public interface IRegistrationRepository
    {
        Task<Registration> Create(Registration user);
        Task<Registration> Authenticate(string email, string password, bool isAdmin);
    }

    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationDbContext _context;

        public RegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create a new user (registration)
        public async Task<Registration> Create(Registration user)
        {
            try
            {
                // Hash the user's password before saving to the database
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _context.Registrations.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during user creation
               
                throw; // Re-throw the exception to be handled at the higher level
            }
        }

        // Authenticate a user by email and password
        public async Task<Registration> Authenticate(string email, string password, bool isAdmin)
        {
            try
            {
                var registration = await _context.Registrations.SingleOrDefaultAsync(u => u.Email == email);

                if (registration == null || !BCrypt.Net.BCrypt.Verify(password, registration.Password))
                {
                    return null;
                }

                // Check if the user is an admin based on the IsAdmin property in the registration
                if (isAdmin && !registration.IsAdmin)
                {
                    return null; // If isAdmin is true but user is not an admin, return null
                }

                return registration;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during user authentication
                
                throw; // Re-throw the exception to be handled at the higher level
            }
        }
    }
}
