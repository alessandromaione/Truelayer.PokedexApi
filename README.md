# Truelayer.PokedexApi

This is a .net 8 api, that expose some endpoint to get informations about pokemons.

Endpoints:
1. /pokemon/pokemonname
2. /pokemon/translated/pokemonname

You can use it also using swagger to the endpoint: http://localhost:5000/swagger

You can run using docker:
1. Install docker
2. Go to the root project folder using you cmd
3. create the image with: docker build -t pokedexapi:1.0 .
4. run it with: docker run -p 8080:5000 pokedexapi:1.0
5. Now you can reach the web api at localhost http://localhost:5000

You can run using the cmd line:
1. Install .net 8 sdk
2. Go to the root project folder using your cmd
3. Type: dotnet run -- --urls "http://localhost:5000" 
