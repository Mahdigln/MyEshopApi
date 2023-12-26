using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Address
{
    [Key]
    public int AddressId { get; set; }

    public string State { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }

    // Navigation Propertybb
    // Navigation Propertybb
    // Navigation Propertybb
    // Navigation Propertybb
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
}