﻿namespace SDK.Domain.Electricity
{
    public class ElectricitySnap
    {
        public Guid Id { get; }
        public int DayConsumption { get; }
        public int NightConsumption { get; }
        public DateTime DateTime { get; }

        public ElectricitySnap(int dayConsumption, int nightConsumption, DateTime dateTime)
            : this(null, dayConsumption, nightConsumption, dateTime)
        {  }

        public ElectricitySnap(string id, int dayConsumption, int nightConsumption, DateTime dateTime) 
        { 
            if (id == null)
            {
                Id = Guid.NewGuid();
            }

            DayConsumption = dayConsumption;
            NightConsumption = nightConsumption;
            DateTime = dateTime;
        }


    }
}
