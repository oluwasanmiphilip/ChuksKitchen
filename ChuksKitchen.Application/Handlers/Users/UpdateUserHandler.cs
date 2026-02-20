using MediatR;
using Application.Commands.Users;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Handlers.Users;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IUserRepository _repository;

    public UpdateUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        // Fetch existing user from DB
        var existingUser = await _repository.GetByIdAsync(request.Id);
        if (existingUser is null) return false;

        // Create a new record with updated values (map Phone -> PhoneNumber)
        var updatedUser = existingUser with
        {
            Email = request.Email,
            PhoneNumber = request.Phone
            // You can also update ReferralCode or Verified if needed
        };

        // Save changes (repository returns Task, not Task<bool>)
        await _repository.UpdateAsync(updatedUser);
        return true;
    }
}