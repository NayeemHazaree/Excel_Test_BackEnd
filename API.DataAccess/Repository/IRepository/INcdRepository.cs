using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess.Repository.IRepository
{
    public interface INcdRepository
    {
        Task RemoveAll(Guid patientId);
    }
}
