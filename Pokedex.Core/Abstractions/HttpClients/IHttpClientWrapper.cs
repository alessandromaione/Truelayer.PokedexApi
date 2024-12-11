namespace Pokedex.Core.Abstractions.HttpClients
{
    public interface IHttpClientWrapper
    {
        Task<T?> ReadAsync<T>(string requestUri);
    }
}
