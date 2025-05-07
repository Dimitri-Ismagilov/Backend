using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class AddProjectFormData
{
    [Required]
    public string ProjectName { get; set; } = null!;

    [Required]
    public string? Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    public decimal Budget { get; set; }

    [Required]
    public string ClientId { get; set; } = null!;

    public int StatusId { get; set; }

    [Required]
    public string UserId { get; set; } = null!;
}
