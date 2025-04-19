using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class MemberEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? MemberImage { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? JobTitle { get; set; }
    public string? MemberRole { get; set; }
    public string? Address { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    public virtual ICollection<ProjectEntity> Projects { get; set; } = [];
}