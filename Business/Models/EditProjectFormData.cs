using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class EditProjectFormData
{
    [Required]
    public string Id { get; set; } = null!;
    public string? ProjectImage { get; set; }

    [Required]
    public string ProjectName { get; set; } = null!;

    [Required]
    public string ClientId { get; set; } = null!;

    public string? ProjectDescription { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [Required]
    public string MemberId { get; set; } = null!;

    public decimal? Budget { get; set; }

    [Required]
    public int StatusId { get; set; }
}
