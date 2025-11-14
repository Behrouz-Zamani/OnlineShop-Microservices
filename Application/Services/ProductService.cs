
using System.Runtime.InteropServices.Marshalling;
using Application.Interfaces;
using Core.Entities;
using Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;
 
namespace Application.Services;
public class ProductService : IProductService
{

    private readonly OnlineShopDbContext _context;
    public ProductService(OnlineShopDbContext context)
    {
        _context = context;
    }
    public async Task<ProductDto> Add(ProductDto model)
    {
        var product = new Product
        {
            ProductName = model.ProductName,
            Price = model.Price,
        };
       await _context.AddAsync(product);
        await _context.SaveChangesAsync();
        model.Id = product.Id;
        return model;
  
    }

    public async Task<ProductDto> Get(int id)
    {
        var product = await _context.Products.FindAsync(id);
        var model = new ProductDto
        {
            Id = product.Id,
            Price = product.Price,
            ProductName = product.ProductName,
            PriceWithComma = product.Price.ToString("###.##"),
        };

        return model;
    }

    public async Task<List<ProductDto>> GetAll()
    {
        var result = await _context.Products.Select(product => new ProductDto
        {
            Id = product.Id,
            Price = product.Price,
            ProductName = product.ProductName,
            PriceWithComma = product.Price.ToString("###.###"),
        }).ToListAsync();
        return result;
    }
}