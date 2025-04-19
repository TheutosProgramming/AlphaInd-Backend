using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Project
{
    [Required]
    public string Id { get; set; } = null!;
    public string? ProjectImage { get; set; }
    [Required]
    public string ProjectName { get; set; } = null!;

    [Required]
    public virtual Client Client { get; set; } = null!;

    public string? ProjectDescription { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [Required]
    public virtual Member Member { get; set; } = null!;

    public decimal? Budget { get; set; }

    [Required]
    public virtual Status Status { get; set; } = null!;
}
