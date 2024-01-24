using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK.Domain.Electricity;
using SDK.Repositories.Dtos;
using SDK.Tools;

namespace SDK.Repositories
{
    public class ElectricitySnapsRepositoryInFile : IElectricitySnapsRepository
    {
        public async Task Create(ElectricitySnap snap)
        {
            var snapDto = ElectricitySnapDto.FromDomin(snap);
            var record = new List<ElectricitySnapDto>() { snapDto };

            await FileSerializer.WriteAsync(record);
        }

        public async Task<ElectricitySnap?> Get(string id)
        {
            var records = await FileSerializer.ReadAsync<ElectricitySnapDto>();
            var record = records.FirstOrDefault(rec => rec.Id == id);
            if (record == null)
            {
                return null;
            }

            return record.ToDomain();
        }

        public async Task<IEnumerable<ElectricitySnap>> Get(ElectricitySnapSearchCriteria filter)
        {
            var records = await FileSerializer.ReadAsync<ElectricitySnapDto>();

            return records.Select(rec => rec.ToDomain());
        }

        public async Task Update(ElectricitySnap snap)
        {
            var records = await FileSerializer.ReadAsync<ElectricitySnapDto>();

            var idValue = snap.Id.ToString();
            var existedRecord = records.FirstOrDefault(rec => rec.Id == idValue);
            if (existedRecord == null)
            {
                throw new Exception($"Record with Id = {idValue} does not exist!");
            }

            existedRecord.DayConsumption = snap.DayConsumption;
            existedRecord.NightConsumption = snap.NightConsumption;
            existedRecord.DateTime = snap.RecordTime;

            await FileSerializer.WriteAsync(records);
        }

        public async Task Delete(string id)
        {
            var records = await FileSerializer.ReadAsync<ElectricitySnapDto>();

            var existedRecordToDelete = records.FirstOrDefault(rec => rec.Id == id);
            if (existedRecordToDelete == null)
            {
                throw new Exception($"Record with Id = {id} does not exist!");
            }

            records.ToList().Remove(existedRecordToDelete);
            await FileSerializer.WriteAsync(records);
        }
    }
}
