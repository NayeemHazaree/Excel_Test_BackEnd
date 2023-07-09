using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess.Repository.IRepository
{
    public interface IPatientRepository
    {
        Task UpdatePatient(Patient patient);
    }
}
