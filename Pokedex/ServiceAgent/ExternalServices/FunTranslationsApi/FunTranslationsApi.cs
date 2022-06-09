using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.ExternalServices.FunTranslationsApi
{
    public class FunTranslationsApi : IFunTranslationsApi
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string baseUrl;

        public FunTranslationsApi(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            baseUrl = configuration.GetSection("ExternalServicesUrl").GetSection("FunTranslationsApiBaseUrl").Value;
        }

        public async Task<FunTranslationsResponse> GetShakespeareTranslation(string text)
        {
            var httpClient = httpClientFactory.CreateClient();
            var httpResponse = await httpClient.GetAsync($"{baseUrl}shakespeare.json?text={text}");

            var result = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FunTranslationsResponse>(result);
        }

        public async Task<FunTranslationsResponse> GetYodaTranslation(string text)
        {
            var httpClient = httpClientFactory.CreateClient();
            var httpResponse = await httpClient.GetAsync($"{baseUrl}yoda.json?text={text}");

            var result = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FunTranslationsResponse>(result);
        }
    }
}
