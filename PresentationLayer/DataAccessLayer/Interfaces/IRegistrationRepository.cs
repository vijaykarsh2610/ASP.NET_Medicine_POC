using DataAccessLayer.Entities;
// IRegistrationRepository.cs
using System.Collections.Generic;


namespace DataAccessLayer.Interfaces
{
   
    public interface IRegistrationRepository
    {

        void AddRegistration(Registration registration);
        Registration GetRegistrationByEmail(string email);
    }

}
