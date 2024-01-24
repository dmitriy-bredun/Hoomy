using ApiServer.Controllers.Dtos;
using Microsoft.AspNetCore.Mvc;
using SDK.Domain.Electricity;
using SDK.Repositories;

namespace ApiServer.Controllers
{
    [ApiController]
    public class ElelctricitySnapsController : ControllerBase
    {
        private readonly IElectricitySnapsRepository electricitySnapsRepository;

        public ElelctricitySnapsController(IElectricitySnapsRepository electricitySnapsRepository)
        {
            this.electricitySnapsRepository = electricitySnapsRepository;
        }

        [HttpPost("api/electicity/snaps")]
        public async Task<ActionResult> CreateElectricitySnap([FromBody] ElectricitySnapDto electricitySnapDto)
        {
            await electricitySnapsRepository.Create(electricitySnapDto.ToDomain());
            return NoContent();
        }

        [HttpGet("api/electicity/snaps/{id}")]
        public async Task<ActionResult> GetElectricitySnap(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return new BadRequestObjectResult("Id code is not specified");
            }

            var result = await electricitySnapsRepository.Get(id);

            return Ok(result);
        }

        [HttpGet("api/electricity/snaps")]
        public async Task<ActionResult<ElectricitySnapsDto>> GetElectricitySnap(
            DateTime? dateFrom = null, 
            DateTime? dateTo = null)
        {
            var criteria = new ElectricitySnapSearchCriteria()
            {
                DateFrom = dateFrom,
                DateTo = dateTo
            };

            var records = await electricitySnapsRepository.Get(criteria);
            var result = new ElectricitySnapsDto()
            {
                ElectricitySnaps = records.Select(rec => ElectricitySnapDto.FromDomin(rec)),
                TotalCount = (uint)records.Count()
            };

            return Ok(records);
        }

        [HttpPut("api/electicity/snaps/{id}")]
        public async Task<ActionResult> UpdateElectricitySnap(string id, [FromBody] ElectricitySnapDto electricitySnapToUpdate)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return new BadRequestObjectResult("Id code is not specified");
            }

            var existingRecord = await electricitySnapsRepository.Get(id);
            if (existingRecord == null)
            {
                return new BadRequestObjectResult("Record with such id is not found");
            }

            var recordWithUpdates = new ElectricitySnap(
                existingRecord.Id.ToString(),
                electricitySnapToUpdate.DayConsumption,
                electricitySnapToUpdate.NightConsumption,
                electricitySnapToUpdate.DateTime);

            await electricitySnapsRepository.Update(recordWithUpdates);

            return NoContent();
        }

        [HttpDelete("api/electicity/snaps/{id}")]
        public async Task<ActionResult> DeleteElectricitySnap(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return new BadRequestObjectResult("Id code is not specified");
            }

            await electricitySnapsRepository.Delete(id);

            return NoContent();
        }

    }
}
