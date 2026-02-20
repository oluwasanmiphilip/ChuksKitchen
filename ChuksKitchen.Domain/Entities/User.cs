public record User
{
    public Guid Id { get; init; }
    public string Email { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public string ReferralCode { get; init; } = string.Empty; // NEW
    public bool IsActive { get; set; } = true;                // NEW
    public bool Verified { get; set; }
    public string SignupStatus { get; set; } = "Pending";
    public string OtpCode { get; set; } = string.Empty;
    public DateTime? OtpExpiry { get; set; }
}