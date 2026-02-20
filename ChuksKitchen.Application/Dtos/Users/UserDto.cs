namespace Application.DTOs.Users;

public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string ReferralCode { get; set; } = string.Empty;
    public bool Verified { get; set; }
}