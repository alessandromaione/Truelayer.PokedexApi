# Truelayer.PokedexApi

This is a .net 8 api, that expose some endpoint to get informations about pokemons.

I tried to create a basic layered web api.
Main Web Api: expose endpoints and return him dto result
The Core: business logic and all the abstractions are declared there. It will not have any dependencies on other layers.
The Infrastructure: useful to communicate with external database, web api and so on.

Endpoints:
1. /pokemon/pokemonname
2. /pokemon/translated/pokemonname

You can use it also using swagger to the endpoint: http://localhost:5000/swagger
---
You can run using docker:
---
1. Install docker
2. Go to the root project folder using you cmd
3. create the image with: docker build -t pokedexapi:1.0 .
4. run it with: docker run -p 8080:5000 pokedexapi:1.0
5. Now you can reach the web api at localhost http://localhost:5000

You can run using the cmd line:
---
1. Install .net 8 sdk
2. Go to the ./Pokedex.Api project folder using your cmd
3. Type: dotnet run -- --urls "http://localhost:5000" 

Yuo can run unit test:
---
1. Go to the ./Pokedex.UnitTest folder using your cmd
2. Type: dotnet test

Next improvements:
1. Create the TranslationService and move the logic inside, so it will be also testable.
2. Modify the NotFound errors to reduce some code that is duplicated.
3. Authentication to the web api should be added.
4. Retry policy could be added.
5. Cache layer should be added to the endpoints.
