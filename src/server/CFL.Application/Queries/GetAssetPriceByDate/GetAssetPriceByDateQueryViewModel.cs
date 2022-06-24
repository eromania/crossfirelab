using AutoMapper;
using CFL.Application.Mapping;
using CFL.Domain;

namespace CFL.Application.Queries.GetAssetPriceByDate;

public class GetAssetPriceByDateQueryViewModel : IMapFrom<ExchangeRate>
{
    public DateTime Time { get; set; }
    public decimal Rate { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExchangeRate, GetAssetPriceByDateQueryViewModel>();
    }
}