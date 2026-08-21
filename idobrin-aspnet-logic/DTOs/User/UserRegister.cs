using System.ComponentModel.DataAnnotations;

namespace idobrin_aspnet_logic.DTOs.User;

public class UserRegister
{
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [StringLength(256, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string Email { get; set; }
}