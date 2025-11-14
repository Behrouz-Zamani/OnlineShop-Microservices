using AutoMapper;
using Core.IRepositories;
using MediatR;

namespace Application.CQRS.ProductCommandQuery.Query;
public class GetProductQuery:IRequest<GetProductQueryResponce>
{
    public int Id { get; set; }
}

public class GetProductQueryResponce
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string PriceWithComma { get; set; }
}

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryResponce>
{

    private readonly IProductRepository _ripo;
    private readonly IMapper _mapper;
    public GetProductQueryHandler(IProductRepository ripo,IMapper mapper)
    {
        _ripo=ripo;
        _mapper=mapper;
    }
    public async Task<GetProductQueryResponce> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product=await _ripo.GetAsync(request.Id);
        var result=  _mapper.Map<GetProductQueryResponce>(product);
        return result;
    }
}