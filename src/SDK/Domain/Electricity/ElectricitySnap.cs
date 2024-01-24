namespace SDK.Domain.Electricity
{
    public class ElectricitySnap
    {
        public Guid Id { get; }
        public int DayConsumption { get; }
        public int NightConsumption { get; }
        public DateTime? RecordTime { get; }

        public ElectricitySnap(int dayConsumption, int nightConsumption, DateTime? dateTime = null)
            : this(null, dayConsumption, nightConsumption, dateTime)
        {  }

        public ElectricitySnap(string id, int dayConsumption, int nightConsumption, DateTime? dateTime) 
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid() : Guid.Parse(id);
            DayConsumption = dayConsumption;
            NightConsumption = nightConsumption;
            RecordTime = dateTime.HasValue ? dateTime : DateTime.Now;
        }
    }
}