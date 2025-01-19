using MarvelApiMaui.Services;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MarvelApiMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly DragonBallApiService _dragonBallApiService;

        public MainPage()
        {
            InitializeComponent();
            _dragonBallApiService = new DragonBallApiService();
        }

        private async void OnSearchCharacterByNameClicked(object sender, EventArgs e)
        {
            string characterName = CharacterNameEntry.Text;

            if (!string.IsNullOrEmpty(characterName))
            {
                try
                {
                    var characterData = await _dragonBallApiService.GetCharacterDataByNameAsync(characterName);

                    if (characterData != null)
                    {
                        var characterInfo = characterData.RootElement.EnumerateArray().FirstOrDefault();
                        if (characterInfo.ValueKind != JsonValueKind.Undefined)
                        {
                            string name = characterInfo.GetProperty("name").GetString() ?? "Nombre no disponible";
                            string description = characterInfo.GetProperty("description").GetString() ?? "Descripción no disponible";
                            string imageUrl = characterInfo.GetProperty("image").GetString() ?? "Imagen no disponible";

                            ResultLabel.Text = $"Nombre: {name}\nDescripción: {description}\nImagen: {imageUrl}";
                        }
                        else
                        {
                            ResultLabel.Text = "No se encontraron datos";
                        }
                    }
                    else
                    {
                        ResultLabel.Text = "No se encontraron datos";
                    }
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = $"Error al obtener datos: {ex.Message}";
                }
            }
            else
            {
                ResultLabel.Text = "Por favor, ingresa un nombre de personaje";
            }

            SemanticScreenReader.Announce(ResultLabel.Text);
        }

        private async void OnSearchCharacterByIdClicked(object sender, EventArgs e)
        {
            string characterId = CharacterIdEntry.Text;

            if (!string.IsNullOrEmpty(characterId))
            {
                try
                {
                    var characterData = await _dragonBallApiService.GetCharacterDataByIdAsync(characterId);

                    if (characterData != null)
                    {
                        var characterInfo = characterData.RootElement;
                        if (characterInfo.ValueKind != JsonValueKind.Undefined)
                        {
                            string name = characterInfo.GetProperty("name").GetString() ?? "Nombre no disponible";
                            string description = characterInfo.GetProperty("description").GetString() ?? "Descripción no disponible";
                            string imageUrl = characterInfo.GetProperty("image").GetString() ?? "Imagen no disponible";

                            ResultLabel.Text = $"Nombre: {name}\nDescripción: {description}\nImagen: {imageUrl}";
                        }
                        else
                        {
                            ResultLabel.Text = "No se encontraron datos";
                        }
                    }
                    else
                    {
                        ResultLabel.Text = "No se encontraron datos";
                    }
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = $"Error al obtener datos: {ex.Message}";
                }
            }
            else
            {
                ResultLabel.Text = "Por favor, ingresa un ID de personaje";
            }

            SemanticScreenReader.Announce(ResultLabel.Text);
        }

        private async void OnSearchPlanetByNameClicked(object sender, EventArgs e)
        {
            string planetName = PlanetNameEntry.Text;

            if (!string.IsNullOrEmpty(planetName))
            {
                try
                {
                    var planetData = await _dragonBallApiService.GetPlanetDataByNameAsync(planetName);

                    if (planetData != null)
                    {
                        var planetInfo = planetData.RootElement.EnumerateArray().FirstOrDefault();
                        if (planetInfo.ValueKind != JsonValueKind.Undefined)
                        {
                            string name = planetInfo.GetProperty("name").GetString() ?? "Nombre no disponible";
                            string description = planetInfo.GetProperty("description").GetString() ?? "Descripción no disponible";
                            string imageUrl = planetInfo.GetProperty("image").GetString() ?? "Imagen no disponible";

                            ResultLabel.Text = $"Nombre: {name}\nDescripción: {description}\nImagen: {imageUrl}";
                        }
                        else
                        {
                            ResultLabel.Text = "No se encontraron datos";
                        }
                    }
                    else
                    {
                        ResultLabel.Text = "No se encontraron datos";
                    }
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = $"Error al obtener datos: {ex.Message}";
                }
            }
            else
            {
                ResultLabel.Text = "Por favor, ingresa un nombre de planeta";
            }

            SemanticScreenReader.Announce(ResultLabel.Text);
        }

        private async void OnSearchPlanetByIdClicked(object sender, EventArgs e)
        {
            string planetId = PlanetIdEntry.Text;

            if (!string.IsNullOrEmpty(planetId))
            {
                try
                {
                    var planetData = await _dragonBallApiService.GetPlanetDataByIdAsync(planetId);

                    if (planetData != null)
                    {
                        var planetInfo = planetData.RootElement;
                        if (planetInfo.ValueKind != JsonValueKind.Undefined)
                        {
                            string name = planetInfo.GetProperty("name").GetString() ?? "Nombre no disponible";
                            string description = planetInfo.GetProperty("description").GetString() ?? "Descripción no disponible";
                            string imageUrl = planetInfo.GetProperty("image").GetString() ?? "Imagen no disponible";

                            ResultLabel.Text = $"Nombre: {name}\nDescripción: {description}\nImagen: {imageUrl}";
                        }
                        else
                        {
                            ResultLabel.Text = "No se encontraron datos";
                        }
                    }
                    else
                    {
                        ResultLabel.Text = "No se encontraron datos";
                    }
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = $"Error al obtener datos: {ex.Message}";
                }
            }
            else
            {
                ResultLabel.Text = "Por favor, ingresa un ID de planeta";
            }

            SemanticScreenReader.Announce(ResultLabel.Text);
        }
    }
}