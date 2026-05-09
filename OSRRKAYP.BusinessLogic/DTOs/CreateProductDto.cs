namespace OSRRKAYP.BusinessLogic.DTOs
{
    public class CreateProductDto
    {
        public int ManufacturerId { get; set; }

        public string Name { get; set; } = null!;

        public decimal PublicPrice { get; set; }

        public int CurrentInventory { get; set; }
    }
}