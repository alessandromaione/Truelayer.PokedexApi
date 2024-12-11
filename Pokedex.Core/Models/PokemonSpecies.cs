using Pokedex.Core.Extensions;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Pokedex.Core.Models
{
    public class PokemonSpecies
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public Habitat Habitat { get; set; }

        [JsonPropertyName("flavor_text_entries")]
        public IEnumerable<FlavorTextEntry> FlavorTextEntries { get; set; } = [];

        [JsonPropertyName("base_happiness")]
        public int BaseHappiness { get; set; }

        [JsonPropertyName("capture_rate")]
        public int CaptureRate { get; set; }

        [JsonPropertyName("forms_switchable")]
        public bool FormsSwitchable { get; set; }

        [JsonPropertyName("gender_rate")]
        public int GenderRate { get; set; }

        [JsonPropertyName("has_gender_differences")]
        public bool HasGenderDifferences { get; set; }

        [JsonPropertyName("hatch_counter")]
        public int HatchCounter { get; set; }

        [JsonPropertyName("is_baby")]
        public bool IsBaby { get; set; }

        [JsonPropertyName("is_legendary")]
        public bool IsLegendary { get; set; }

        [JsonPropertyName("is_mythical")]
        public bool IsMythical { get; set; }

        public string? Description
           => FlavorTextEntries
            .FirstOrDefault(s => s.HasLanguage && s.Language.Name.EqualsIgnoreCase(Constants.Language.English))?.FlavorText;
    }
}