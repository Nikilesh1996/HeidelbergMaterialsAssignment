using AutoMapper;
using SpaceXSearchWebApp.Common.Abstractions.Models;

namespace SpaceXSearchWebApp.Common.Contracts
{
    public interface IApiUtils
    {
        HttpClient GetDefaultHttpClientRequest(HttpRequestParams requestParams);
        IMapper GetMapper<T>() where T : Profile, new();
    }
}
