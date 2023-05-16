using SpaceXSearchWebApp.Common.Contracts;
using SpaceXSearchWebApp.Common.Abstractions.Models;
using AutoMapper;

namespace SpaceXSearchWebApp.Common.Utils
{
    public class ApiUtils : IApiUtils
    {
        public HttpClient GetDefaultHttpClientRequest(HttpRequestParams requestParams)
        {
            var httpClientRequest = new HttpClient
            {
                BaseAddress = requestParams.BaseUrl
            };

            return httpClientRequest;
        }

        public IMapper GetMapper<T>() where T : Profile, new()
        {
            var profile = new T();
            var mapperConfiguration = new MapperConfiguration(config => config.AddProfile(profile));
            return mapperConfiguration.CreateMapper();
        }
    }
}
