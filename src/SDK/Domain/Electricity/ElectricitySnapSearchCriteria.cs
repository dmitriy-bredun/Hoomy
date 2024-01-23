namespace SDK.Domain.Electricity
{
    public enum ElectricityReportType
    {
        Year,
        Month,
        Week
    }

    public class ElectricitySnapSearchCriteria
    {
        public ElectricityReportType PeriodType { get; set; }
        public int Number { get; set; }
    }
}