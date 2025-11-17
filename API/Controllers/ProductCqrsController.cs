using Application.CQRS.ProductCommandQuery.Command;
using Application.CQRS.ProductCommandQuery.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Controller]
[Route("api/[controller]")]
public class ProductCqrsColntroller : ControllerBase
{
    #region CTOR
            private readonly IMediator _mediator;
    public ProductCqrsColntroller(IMediator mediator)
    {
        _mediator=mediator;
    }
    #endregion


    [HttpPost]
    public async Task<IActionResult> Create(SaveProductCommand command)
    {
        var result=await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("id")]
public async Task<IActionResult> Get([FromQuery]GetProductQuery getProduct)
    {
        return Ok(await _mediator.Send(getProduct)) ;
    }

}