using DataProvider.Models;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace DataProvider.Repositories
{
    public class ScriptGenerationHistoriesRepository : ScriptGenerationHistoryRepository.ScriptGenerationHistoryRepositoryBase
    {
        private readonly AppDbContext _dbContext;
        public ScriptGenerationHistoriesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override async Task<ScriptGenerationHistoriesResponse> Get(HistoryQueryParameters request, ServerCallContext context)
        {
            var pageNumber = request.PaginationParameters.PageNumber;
            var pageSize = request.PaginationParameters.PageSize;

            var query = _dbContext.ScriptGenerationHistories.AsQueryable();
            if (request.Dialect != -1)
                query = query.Where(h => h.Dialect == (DatabaseDialect)request.Dialect);
            if (request.DateTo != null)
                query = query.Where(h => h.RequestedAt <= request.DateTo.ToDateTime());
            if(request.DateFrom != null)
                query = query.Where(h => h.RequestedAt >= request.DateFrom.ToDateTime());

            var histories = await query.AsNoTracking()
                .OrderBy(h => h.RequestedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(h => new ScriptGenerationHistoryResponse()
                {
                    Quantity = h.Quantity,
                    Dialect = h.Dialect,
                    RequestedAt = h.RequestedAt.ToTimestamp()
                })
                .ToListAsync();


            var response = new ScriptGenerationHistoriesResponse();
            response.Histories.AddRange(histories);

            return response;
        }
        public override async Task<Empty> Add(AddScriptGenerationHistoryRequest request, ServerCallContext context)
        {
            var scriptGenerationHistory = new ScriptGenerationHistory()
            {
                Quantity = request.Quantity,
                Dialect = request.Dialect,
                RequestedAt = request.RequestedAt.ToDateTime()
            };
            await _dbContext.AddAsync(scriptGenerationHistory);
            await _dbContext.SaveChangesAsync();

            return new Empty();
        }
        public override async Task<Empty> Delete(Empty request, ServerCallContext context)
        {
            await _dbContext.ScriptGenerationHistories.ExecuteDeleteAsync();

            return new Empty();
        }

    }
}
