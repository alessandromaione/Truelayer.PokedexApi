using Pokedex.Core.Extensions;

namespace Pokedex.Core.Results
{
    public class PokemonResult
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Habitat { get; set; }

        public bool IsLegendary { get; set; }

        public bool IsCave
            => Habitat.EqualsIgnoreCase(Constants.Habitat.Cave);
    }
}