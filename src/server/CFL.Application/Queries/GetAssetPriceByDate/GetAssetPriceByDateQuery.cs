using MediatR;

namespace CFL.Application.Queries.GetAssetPriceByDate;

public class GetAssetPriceByDateQuery : IRequest<List<GetAssetPriceByDateQueryViewModel>>
{
    public int Days { get; set; }
}