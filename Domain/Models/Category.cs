using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string Name { get; set; }

    // Navigation Property
    public List<Product> Products { get; set; }
}