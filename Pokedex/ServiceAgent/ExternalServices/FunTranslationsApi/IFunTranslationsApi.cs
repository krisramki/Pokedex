using System.Threading.Tasks;

namespace Pokedex.ExternalServices.FunTranslationsApi
{
    public interface IFunTranslationsApi
    {
        Task<FunTranslationsResponse> GetShakespeareTranslation(string text);

        Task<FunTranslationsResponse> GetYodaTranslation(string text);
    }
}
