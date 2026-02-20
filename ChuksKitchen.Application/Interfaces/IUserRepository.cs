public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByReferralCodeAsync(string referralCode);
    Task<bool> ExistsByEmailOrPhoneAsync(string email, string phone);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
}