using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace DataAccessLayer.Interfaces
{

    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly DbContext _dbContext;

        public RegistrationRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRegistration(Registration registration)
        {
            _dbContext.Set<Registration>().Add(registration);
            _dbContext.SaveChanges();
        }

        public Registration GetRegistrationByEmail(string email)
        {
            return _dbContext.Set<Registration>().FirstOrDefault(r => r.Email == email);
        }
    }
}