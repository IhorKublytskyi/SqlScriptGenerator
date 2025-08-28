using Frontend.Clients;
using Frontend.Interfaces;
using Frontend.Models;
using Refit;

namespace Frontend.Services
{
    public class ScriptGenerationService : IScriptGenerationService
    {
        private readonly IScriptGeneratorApi _scriptGeneratorApi;

        public ScriptGenerationService(IScriptGeneratorApi scriptGeneratorApi)
        {
            _scriptGeneratorApi = scriptGeneratorApi;
        }

        public async ValueTask<string> GetScriptFileAsync(int quantity, int dialect)
        {
            try
            {
                var response = await _scriptGeneratorApi.GetScriptFileAsync(quantity, dialect);

                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Script generation exception", ex);
            }
        }

        public async ValueTask<PagedResult<ScriptGenerationHistory>> GetHistoriesAsync(int pageNumber, int pageSize, QueryParameters queryParameters)
        {
            try
            {
                var response = await _scriptGeneratorApi.GetHistoriesAsync(pageNumber, pageSize, queryParameters);
                return response;
            }
            catch (ApiException ex)
            {
                throw new ApplicationException($"History loading exception: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Unknown exception: {ex.Message}", ex);
            }
        }

        public async ValueTask RemoveHistoryByIdAsync(int id)
        {
            await _scriptGeneratorApi.RemoveById(id);
        }

        public async ValueTask ClearHistoryAsync()
        {
            await _scriptGeneratorApi.ClearHistoryAsync();
        }
    }
}
