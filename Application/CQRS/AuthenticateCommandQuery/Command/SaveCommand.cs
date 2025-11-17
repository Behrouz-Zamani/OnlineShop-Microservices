using Core.Entities;
using Core.IRepositories;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.CQRS.AuthenticateCommandQuery.Command;

public class SaveUserCommand : IRequest<SaveUserCommandResponse>
{
    public Guid Id { get; set; }
    public string  Name { get; set; }
    public string  Password { get; set; }
    public string PasswordSult { get; set; }
}

public class SaveUserCommandResponse
{
    public Guid Id { get; set; }
}


public class SaveUserCommandHandler : IRequestHandler<SaveUserCommand, SaveUserCommandResponse>
{

    private readonly IUserRepository _ripo;
    private readonly IUnitOfWork _work;

    public SaveUserCommandHandler(IUserRepository ripo,IUnitOfWork work)
    {
        _ripo=ripo;
        _work=work;
    }
    public async Task<SaveUserCommandResponse> Handle(SaveUserCommand request, CancellationToken cancellationToken)
    {
        var user=new User
        {
            UserName=request.Name,
            Password=request.Password,
            PasswordSalt=request.PasswordSult
        };

        await _ripo.CreateAsync(user);
        await _work.SaveChangesAsync();

        var result = new SaveUserCommandResponse
        {
            Id=request.Id
        };

        return result;
    }
}