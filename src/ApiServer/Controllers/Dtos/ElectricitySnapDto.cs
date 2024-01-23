using SDK.Domain.Electricity;

namespace ApiServer.Controllers.Dtos
{
    internal class ElectricitySnapDto
    {
        public string Id { get; set; } = "";
        public int DayConsumption { get; set; }
        public int NightConsumption { get; set; }
        public DateTime DateTime { get; set; }

        internal ElectricitySnap ToDomain()
        {
            return new ElectricitySnap(Id, DayConsumption, NightConsumption, DateTime);
        }

        internal static ElectricitySnapDto FromDomin(ElectricitySnap snap)
        {
            return new ElectricitySnapDto()
            {
                Id = snap.Id.ToString(),
                DayConsumption = snap.DayConsumption,
                NightConsumption = snap.NightConsumption,
                DateTime = snap.DateTime
            };
        }
    }
}
