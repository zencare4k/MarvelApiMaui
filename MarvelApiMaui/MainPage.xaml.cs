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
                            string name = characterInfo.TryGetProperty("name", out var nameProperty) ? nameProperty.GetString() ?? "Nombre no disponible" : "Nombre no disponible";
                            string description = characterInfo.TryGetProperty("description", out var descriptionProperty) ? descriptionProperty.GetString() ?? "Descripción no disponible" : "Descripción no disponible";
                            string imageUrl = characterInfo.TryGetProperty("image", out var imageProperty) ? imageProperty.GetString() ?? "Imagen no disponible" : "Imagen no disponible";

                            ResultLabel.Text = $"Nombre: {name}\nDescripción: {description}";
                            ResultImage.Source = imageUrl;
                        }
                        else
                        {
                            ResultLabel.Text = "No se encontraron datos";
                            ResultImage.Source = null;
                        }
                    }
                    else
                    {
                        ResultLabel.Text = "No se encontraron datos";
                        ResultImage.Source = null;
                    }
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = $"Error al obtener datos: {ex.Message}";
                    ResultImage.Source = null;
                }
            }
            else
            {
                ResultLabel.Text = "Por favor, ingresa un nombre de personaje";
                ResultImage.Source = null;
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
                            string name = characterInfo.TryGetProperty("name", out var nameProperty) ? nameProperty.GetString() ?? "Nombre no disponible" : "Nombre no disponible";
                            string description = characterInfo.TryGetProperty("description", out var descriptionProperty) ? descriptionProperty.GetString() ?? "Descripción no disponible" : "Descripción no disponible";
                            string imageUrl = characterInfo.TryGetProperty("image", out var imageProperty) ? imageProperty.GetString() ?? "Imagen no disponible" : "Imagen no disponible";

                            ResultLabel.Text = $"Nombre: {name}\nDescripción: {description}";
                            ResultImage.Source = imageUrl;
                        }
                        else
                        {
                            ResultLabel.Text = "No se encontraron datos";
                            ResultImage.Source = null;
                        }
                    }
                    else
                    {
                        ResultLabel.Text = "No se encontraron datos";
                        ResultImage.Source = null;
                    }
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = $"Error al obtener datos: {ex.Message}";
                    ResultImage.Source = null;
                }
            }
            else
            {
                ResultLabel.Text = "Por favor, ingresa un ID de personaje";
                ResultImage.Source = null;
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
                            string name = planetInfo.TryGetProperty("name", out var nameProperty) ? nameProperty.GetString() ?? "Nombre no disponible" : "Nombre no disponible";
                            string description = planetInfo.TryGetProperty("description", out var descriptionProperty) ? descriptionProperty.GetString() ?? "Descripción no disponible" : "Descripción no disponible";
                           
                            string imageUrl = planetInfo.TryGetProperty("image", out var imageProperty) ? imageProperty.GetString() ?? "Imagen no disponible" : "Imagen no disponible";

                            ResultLabel.Text = $"Nombre: {name}\nDescripción: {description}";
                            ResultImage.Source = imageUrl;
                        }
                        else
                        {
                            ResultLabel.Text = "No se encontraron datos";
                            ResultImage.Source = null;
                        }
                    }
                    else
                    {
                        ResultLabel.Text = "No se encontraron datos";
                        ResultImage.Source = null;
                    }
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = $"Error al obtener datos: {ex.Message}";
                    ResultImage.Source = null;
                }
            }
            else
            {
                ResultLabel.Text = "Por favor, ingresa un nombre de planeta";
                ResultImage.Source = null;
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
                            string name = planetInfo.TryGetProperty("name", out var nameProperty) ? nameProperty.GetString() ?? "Nombre no disponible" : "Nombre no disponible";
                            string description = planetInfo.TryGetProperty("description", out var descriptionProperty) ? descriptionProperty.GetString() ?? "Descripción no disponible" : "Descripción no disponible";
                            string imageUrl = planetInfo.TryGetProperty("image", out var imageProperty) ? imageProperty.GetString() ?? "Imagen no disponible" : "Imagen no disponible";

                            ResultLabel.Text = $"Nombre: {name}\nDescripción: {description}";
                            ResultImage.Source = imageUrl;
                        }
                        else
                        {
                            ResultLabel.Text = "No se encontraron datos";
                            ResultImage.Source = null;
                        }
                    }
                    else
                    {
                        ResultLabel.Text = "No se encontraron datos";
                        ResultImage.Source = null;
                    }
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = $"Error al obtener datos: {ex.Message}";
                    ResultImage.Source = null;
                }
            }
            else
            {
                ResultLabel.Text = "Por favor, ingresa un ID de planeta";
                ResultImage.Source = null;
            }

            SemanticScreenReader.Announce(ResultLabel.Text);
        }

     

        private async void OnSearchTransformationByIdClicked(object sender, EventArgs e)
        {
            string transformationId = TransformationIdEntry.Text;

            if (!string.IsNullOrEmpty(transformationId))
            {
                try
                {
                    var transformationData = await _dragonBallApiService.GetTransformationByIdAsync(transformationId);

                    if (transformationData != null)
                    {
                        var transformationInfo = transformationData.RootElement;
                        if (transformationInfo.ValueKind != JsonValueKind.Undefined)
                        {
                            string name = transformationInfo.TryGetProperty("name", out var nameProperty) ? nameProperty.GetString() ?? "Nombre no disponible" : "Nombre no disponible";
                            string description = transformationInfo.TryGetProperty("description", out var descriptionProperty) ? descriptionProperty.GetString() ?? "Descripción no disponible" : "Descripción no disponible";
                            string imageUrl = transformationInfo.TryGetProperty("image", out var imageProperty) ? imageProperty.GetString() ?? "Imagen no disponible" : "Imagen no disponible";

                            ResultLabel.Text = $"Nombre: {name}\nDescripción: {description}";
                            ResultImage.Source = imageUrl;
                        }
                        else
                        {
                            ResultLabel.Text = "No se encontraron datos";
                            ResultImage.Source = null;
                        }
                    }
                    else
                    {
                        ResultLabel.Text = "No se encontraron datos";
                        ResultImage.Source = null;
                    }
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = $"Error al obtener datos: {ex.Message}";
                    ResultImage.Source = null;
                }
            }
            else
            {
                ResultLabel.Text = "Por favor, ingresa un ID de transformación";
                ResultImage.Source = null;
            }

            SemanticScreenReader.Announce(ResultLabel.Text);
        }
    }
}