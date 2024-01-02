namespace WebApi.DTOs.Product;

public class ProductQueryParametersDto:QueryParametersDto
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string Name { get; set; } = string.Empty;

}