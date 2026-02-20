using Domain.Entities;

namespace Application.Interfaces;

public interface IFoodRepository
{
    Task<Food?> GetByIdAsync(Guid id);
    Task<IEnumerable<Food>> GetAllAsync();
    Task AddAsync(Food food);
    Task<bool> UpdateAsync(Food food);
    Task<bool> DeleteAsync(Guid id);
}