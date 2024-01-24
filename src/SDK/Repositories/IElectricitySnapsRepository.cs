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
