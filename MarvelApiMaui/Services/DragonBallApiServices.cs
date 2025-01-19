using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarvelApiMaui.Services
{
    public class DragonBallApiService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://dragonball-api.com/api";

        public DragonBallApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<JsonDocument> GetCharacterDataByNameAsync(string characterName)
        {
            var url = $"{ApiBaseUrl}/characters?name={characterName}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonDocument.Parse(content);
            }
            
            return null;
        }

        public async Task<JsonDocument> GetCharacterDataByIdAsync(string characterId)
        {
            var url = $"{ApiBaseUrl}/characters/{characterId}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonDocument.Parse(content);
            }

            return null;
        }

        public async Task<JsonDocument> GetPlanetDataByNameAsync(string planetName)
        {
            var url = $"{ApiBaseUrl}/planets?name={planetName}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonDocument.Parse(content);
            }

            return null;
        }

        public async Task<JsonDocument> GetPlanetDataByIdAsync(string planetId)
        {
            var url = $"{ApiBaseUrl}/planets/{planetId}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonDocument.Parse(content);
            }

            return null;
        }
    }
}