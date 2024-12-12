using Pokedex.Core.Extensions;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Pokedex.Core.Models
{
    public class FlavorTextEntry
    {
        [JsonPropertyName("flavor_text")]
        public string FlavorText { get; set; }

        public Language? Language { get; set; }

        [MemberNotNullWhen(true, nameof(Language))]
        public bool HasLanguage
            => Language != null;

        public bool IsEnglish
            => HasLanguage && Language.Name.EqualsIgnoreCase(Constants.Language.English);
    }
}