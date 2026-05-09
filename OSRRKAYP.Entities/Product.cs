namespace OSRRKAYP.Entities
{
    public class Product
    {
        public long Id { get; set; }

        public int ManufacturerId { get; set; }

        public string Name { get; set; } = null!;

        public decimal PublicPrice { get; set; }

        public int CurrentInventory { get; set; }
    }
}