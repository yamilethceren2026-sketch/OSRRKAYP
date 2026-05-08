namespace OSRRKAYP.BusinessLogic.DTOs;

public class ProductDto
{
    public long ProductId { get; set; }

    public int? BrandId { get; set; }

    public string? SupplierName { get; set; }

    public string? ProductCode { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string? ProductDescription { get; set; }

    public string? ProductImage { get; set; }

    public decimal? PriceUnitPurchase { get; set; }

    public decimal? PriceUnitSale { get; set; }

    public int? Stock { get; set; }

    public bool ProductStatus { get; set; }
}