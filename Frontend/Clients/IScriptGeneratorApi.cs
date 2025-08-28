using Frontend.Models;
using Refit;

namespace Frontend.Clients
{
    public interface IScriptGeneratorApi
    {
        [Get("/generation")]
        Task<string> GetScriptFileAsync(int quantity, int dialect);

        [Get("/histories")]
        Task<PagedResult<ScriptGenerationHistory>> GetHistoriesAsync
        (int pageNumber, int pageSize, QueryParameters queryParameters);

        [Delete("/histories")]
        Task ClearHistoryAsync();
        [Delete("/histories/{id}")]
        Task RemoveById(int id);
    }
}
