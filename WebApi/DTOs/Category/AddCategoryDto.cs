using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.Category;

public class AddCategoryDto
{
    [Required]
    public string Name { get; set; }
}