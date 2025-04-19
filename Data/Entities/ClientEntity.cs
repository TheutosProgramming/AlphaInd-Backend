using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ClientEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? ClientImage {  get; set; }
    public string ClientName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? BillingAddress { get; set; }
    public string? PostalCode {  get; set; }
    public string? City { get; set; }
    public string BillingRefrence { get; set; } = null!;

    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Modified {  get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<ProjectEntity> Projects { get; set; } = [];
}