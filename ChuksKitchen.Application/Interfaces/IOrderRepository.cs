using Domain.Entities;

namespace Application.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id);
    Task AddAsync(Order order);
    Task<bool> UpdateAsync(Order order);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<Order>> GetAllAsync();
}