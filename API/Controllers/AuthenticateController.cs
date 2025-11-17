using Application.CQRS.AuthenticateCommandQuery.Command;
using Application.CQRS.AuthenticateCommandQuery.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Controller]
[Route("api/[controller]")]
public class AuthenticateController :ControllerBase
{
    private readonly IMediator _med;
    public AuthenticateController(IMediator med)
    {
        _med=med;   
    }
    [HttpPost]
    public async Task<IActionResult> Post(SaveUserCommand command)
    {
                var result=await _med.Send(command);

        return Ok(result);
    }


        [HttpGet("id")]
    public async Task<IActionResult> GetAll([FromQuery]QueryUserCommand command)
    {
        return Ok(await _med.Send(command)) ;
    }

}

// }