using Application.Interfaces;
using Infrastructure.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _productService.Get(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto model)
    {
        var result = await _productService.Add(model);
        return Ok(result);
    }
}