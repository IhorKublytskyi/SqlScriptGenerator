using Frontend.Models;

namespace Frontend.Interfaces
{
    public interface IScriptGenerationService
    {
        ValueTask<string> GetScriptFileAsync(int quantity, int dialect);
        ValueTask<PagedResult<ScriptGenerationHistory>> GetHistoriesAsync(int pageNumber, int pageSize, QueryParameters queryParameters);
        ValueTask ClearHistoryAsync();
        ValueTask RemoveHistoryByIdAsync(int id);
    }
}
