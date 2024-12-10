﻿using System.Text.Json.Serialization;

namespace Pokedex.Core.Models
{
    public class FlavorTextEntry
    {
        [JsonPropertyName("flavor_text")]
        public string FlavorText { get; set; }

        public Language Language { get; set; }
    }
}