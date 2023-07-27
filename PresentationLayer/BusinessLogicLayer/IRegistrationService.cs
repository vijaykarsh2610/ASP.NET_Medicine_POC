using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    // IRegistrationService.cs
    public interface IRegistrationService
    {
        void Register(Registration registration);
        bool IsEmailAvailable(string email);
    }

}
