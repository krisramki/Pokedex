using System.Text.Json.Serialization;

namespace Pokedex.ExternalServices.FunTranslationsApi
{
    public class Contents
    {
        [JsonPropertyName("translated")]
        public string Translated;

        [JsonPropertyName("text")]
        public string Text;

        [JsonPropertyName("translation")]
        public string Translation;
    }

    public class FunTranslationsResponse
    {
        [JsonPropertyName("success")]
        public Success Success;

        [JsonPropertyName("contents")]
        public Contents Contents;
    }

    public class Success
    {
        [JsonPropertyName("total")]
        public int Total;
    }
}
