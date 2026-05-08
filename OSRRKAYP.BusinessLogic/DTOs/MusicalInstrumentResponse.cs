namespace OSRRKAYP.BusinessLogic.DTOs
{
    public class MusicalInstrumentResponse
    {
        public long Id { get; set; }

        public int ManufacturerId { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal PublicPrice { get; set; }

        public int CurrentInventory { get; set; }
    }
}