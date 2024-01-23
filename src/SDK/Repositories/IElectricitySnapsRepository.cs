using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK.Domain.Electricity;

namespace SDK.Repositories
{
    interface IElectricitySnapsRepository
    {
        Task Create(ElectricitySnap snap);
        Task<ElectricitySnap?> Get(string id);
        Task<IEnumerable<ElectricitySnap>> Find(ElectricitySnapSearchCriteria filter);
        Task Update(ElectricitySnap snap);
        Task Delete(ElectricitySnap snap);
    }
}
