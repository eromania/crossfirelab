using AutoMapper;

namespace CFL.Application.Mapping;

/// <summary>
/// Interface for mapping profiles
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}

