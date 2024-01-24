using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK.Domain.Electricity;

namespace SDK.Repositories
{
    public interface IElectricitySnapsRepository
    {
        Task Create(ElectricitySnap snap);
        Task<ElectricitySnap?> Get(string id);
        Task<IEnumerable<ElectricitySnap>> Get(ElectricitySnapSearchCriteria filter);
        Task Update(ElectricitySnap snap);
        Task Delete(string id);
    }
}
