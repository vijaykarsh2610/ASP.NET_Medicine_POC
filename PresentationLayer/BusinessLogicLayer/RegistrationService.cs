using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    // RegistrationService.cs
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public void Register(Registration registration)
        {
            _registrationRepository.AddRegistration(registration);
        }

        public bool IsEmailAvailable(string email)
        {
            var existingRegistration = _registrationRepository.GetRegistrationByEmail(email);

            return existingRegistration == null;
        }
    }

}
