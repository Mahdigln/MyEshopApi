namespace WebApi.DTOs.Product;

public class UpdateProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public string Description { get; set; }

    public int CategoryId { get; set; }
}