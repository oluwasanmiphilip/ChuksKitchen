public interface ICartRepository
{
    Task<Cart?> GetByUserIdAsync(Guid userId);
    Task AddItemAsync(Guid userId, Guid foodId, int quantity);
    Task RemoveItemAsync(Guid userId, Guid foodId);
    Task ClearAsync(Guid userId);
}