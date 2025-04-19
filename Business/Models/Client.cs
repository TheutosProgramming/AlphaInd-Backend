using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Client
{
    [Required]
    public string Id { get; set; } = null!;
    public string? ClientImage { get; set; }
    [Required]
    public string ClientName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? BillingAddress { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    [Required]
    public string BillingRefrence { get; set; } = null!;

    public DateTime Created { get; set; }
    public DateTime? Modified { get; set; }

    public bool IsActive { get; set; }
}
