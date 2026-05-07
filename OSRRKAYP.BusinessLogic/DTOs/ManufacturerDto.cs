namespace OSRRKAYP.BusinessLogic.DTOs
{
    public class ManufacturerDto
    {
        public string BrandName { get; set; } = string.Empty;
    }

    public class UpdateManufacturerDto
    {
        public int Id { get; set; }

        public string BrandName { get; set; } = string.Empty;
    }

    public class ManufacturerDtoResponse
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; } = string.Empty;
    }
}
