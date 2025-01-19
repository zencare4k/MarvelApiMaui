using MarvelApiMaui.Resources.Services;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarvelApiMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly MarvelApiService _marvelApiService;

        public MainPage()
        {
            InitializeComponent();
            _marvelApiService = new MarvelApiService();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            string characterName = HeroEntry.Text;

            if (!string.IsNullOrEmpty(characterName))
            {
                try
                {
                    var characterData = await _marvelApiService.GetCharacterDataAsync(characterName);

                    if (characterData != null)
                    {
                        // Procesa los datos del personaje aquí
                        var characterInfo = characterData.RootElement.GetProperty("data").GetProperty("results").EnumerateArray().FirstOrDefault();
                        if (characterInfo.ValueKind != JsonValueKind.Undefined)
                        {
                            string name = characterInfo.GetProperty("name").GetString() ?? "Nombre no disponible";
                            string description = characterInfo.GetProperty("description").GetString() ?? "Descripción no disponible";
                            string imageUrl = $"{characterInfo.GetProperty("thumbnail").GetProperty("path").GetString() ?? "Ruta no disponible"}.{characterInfo.GetProperty("thumbnail").GetProperty("extension").GetString() ?? "Extensión no disponible"}";

                            CharacterDataLabel.Text = $"Nombre: {name}\nDescripción: {description}\nImagen: {imageUrl}";
                        }
                        else
                        {
                            CharacterDataLabel.Text = "No se encontraron datos";
                        }
                    }
                    else
                    {
                        CharacterDataLabel.Text = "No se encontraron datos";
                    }
                }
                catch (Exception ex)
                {
                    CharacterDataLabel.Text = $"Error al obtener datos: {ex.Message}";
                }
            }
            else
            {
                CharacterDataLabel.Text = "Por favor, ingresa un nombre de héroe/villano";
            }

            SemanticScreenReader.Announce(CharacterDataLabel.Text);
        }
    }
}