using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class AddUserFormData
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
