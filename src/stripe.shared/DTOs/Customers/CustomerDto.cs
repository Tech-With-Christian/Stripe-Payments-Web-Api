using System;
namespace stripe.shared.DTOs.Customers
{
    public record CustomerDto(
        string Name,
        string Email,
        string CustomerId);
}
