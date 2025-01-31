
using System.ComponentModel.DataAnnotations;

public class UserRegistrationModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string FullName { get; set; }

    public string PhoneNumber { get; set; }
}