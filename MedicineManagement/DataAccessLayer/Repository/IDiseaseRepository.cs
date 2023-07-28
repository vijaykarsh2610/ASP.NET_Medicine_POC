using DataAccessLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IDiseaseRepository
    {
        void Add(Disease disease);
        IEnumerable<Disease> GetAllDiseases();
        void Save();
    }
}
