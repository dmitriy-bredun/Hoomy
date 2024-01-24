namespace ApiServer.Controllers.Dtos
{
    public class ElectricitySnapsDto
    {
        public required IEnumerable<ElectricitySnapDto> ElectricitySnaps { get; set; }
        public uint TotalCount { get; set; }
    }
}
