namespace Application.Handlers.Users;

using MediatR;
using Application.Queries.Users;
using Application.DTOs.Users;
using Application.Interfaces;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUserRepository _repository;

    public GetUserByIdHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);
        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Phone = user.PhoneNumber,
            ReferralCode = user.ReferralCode,
            Verified = user.Verified
        };
    }
}