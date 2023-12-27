﻿namespace Application.Response.Address;

public class AddressQueryResponse
{
    public int AddressId { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }

    public int CustomerId { get; set; }
}