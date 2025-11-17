using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Core.Entities;
using Core.IRepositories;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.CQRS.AuthenticateCommandQuery.Query;

public class QueryUserCommand:IRequest<QueryUserCommandResponse>
{
    public Guid Id { get; set; }
}

public class QueryUserCommandResponse
{
     public Guid Id { get; set; }
    public string  Name { get; set; }
    public string  Password { get; set; }
    public string PasswordSult { get; set; }
}

public class QueryUserCommandHandler : IRequestHandler<QueryUserCommand, QueryUserCommandResponse>
{

    private readonly IUserRepository _ripo;
    private readonly IMapper _mapper;

    public QueryUserCommandHandler(IUserRepository ripo,IMapper mapper)
    {
        _ripo=ripo;
        _mapper=mapper;
    }


    public async Task<QueryUserCommandResponse> Handle(QueryUserCommand request, CancellationToken cancellationToken)
    {
        var user =await  _ripo.GetAsync(request.Id);
        var result=_mapper.Map<QueryUserCommandResponse>(user);
        return result;
    }
}