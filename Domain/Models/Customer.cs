using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Domain.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }


    // Navigation Property
    public List<Address> Addresses { get; set; }
    public List<Order> Orders { get; set; }
  
}