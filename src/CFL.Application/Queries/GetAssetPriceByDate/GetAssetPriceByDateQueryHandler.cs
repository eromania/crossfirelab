using AutoMapper;
using AutoMapper.QueryableExtensions;
using CFL.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CFL.Application.Queries.GetAssetPriceByDate;

public class
    GetAssetPriceByDateQueryHandler : IRequestHandler<GetAssetPriceByDateQuery, List<GetAssetPriceByDateQueryViewModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAssetPriceByDateQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetAssetPriceByDateQueryViewModel>> Handle(GetAssetPriceByDateQuery request,
        CancellationToken
            cancellationToken)
    {
        var result = await _context.ExchangeRates
            .Where(c => c.IsValid == 1
                        && c.Time > DateTime.Now.AddDays(-request.Days))
            .OrderBy(c => c.Time)
            .AsNoTracking()
            .ProjectTo<GetAssetPriceByDateQueryViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result;
    }
}