namespace Application.Response.Product;

public class ProductQueryParametersResponse: QueryParametersResponse
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }

    public string Name { get; set; } = string.Empty;

}
