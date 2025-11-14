using MediatR;

namespace Application.CQRS.AuthenticateCommandQuery.Command;

public class LoginCommand :IRequest<LoginCommandResponce>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class LoginCommandResponce
{
    public string UserName { get; set; }
    public string Token { get; set; }
    public int ExpireTime { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponce>
{

    public Task<LoginCommandResponce> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}