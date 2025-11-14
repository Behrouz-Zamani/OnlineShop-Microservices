using System.Runtime.InteropServices;
using Azure;
using Core.Entities;
using Core.IRepositories;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Application.CQRS.ProductCommandQuery.Command;
public class SaveProductCommand :IRequest<SaveProductCommandResponce>
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public long Price { get; set; }
    public string Description  { get; set; }
}

public class SaveProductCommandResponce
{
    public int Id { get; set; }
}

public class SaveProductCommandHandler : IRequestHandler<SaveProductCommand, SaveProductCommandResponce>
{
    // private readonly OnlineShopDbContext _context;
    // public SaveProductCommandHandler(OnlineShopDbContext context)
    // {
    //     _context=context;
    // }

    private readonly IProductRepository _ripo;
    private readonly IUnitOfWork _work;
    public SaveProductCommandHandler(IProductRepository ripo,IUnitOfWork work)
    {
        _ripo=ripo;
        _work=work;
    }
    public async Task<SaveProductCommandResponce> Handle(SaveProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            ProductName=request.ProductName,
            Price=request.Price,

        };
        // await _context.Products.AddAsync(product);
        // await _context.SaveChangesAsync();

        await _ripo.InsertAsync(product);
        await _work.SaveChangesAsync();

        var result = new SaveProductCommandResponce
        {
            Id=request.Id,
        };

        return result;
    }
}