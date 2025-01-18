using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarvelApiMaui.Services
{
    public class MarvelApiService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://gateway.marvel.com/v1/public";
        private const string ApiKey = "YOUR_PUBLIC_API_KEY"; // Reemplaza con tu clave pública de la API de Marvel
        private const string Hash = "YOUR_HASH"; // Reemplaza con el hash generado
        private const string Timestamp = "YOUR_TIMESTAMP"; // Reemplaza con el timestamp usado para generar el hash

        public MarvelApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<JsonDocument> GetCharacterDataAsync(string characterName)
        {
            var url = $"{ApiBaseUrl}/characters?name={characterName}&apikey={ApiKey}&ts={Timestamp}&hash={Hash}";
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