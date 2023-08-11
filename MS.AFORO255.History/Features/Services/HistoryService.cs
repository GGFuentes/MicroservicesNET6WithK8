using MongoDB.Driver;
using MS.AFORO255.History.Features.DTOs;
using MS.AFORO255.History.Features.Models;
using MS.AFORO255.History.Persistences;

namespace MS.AFORO255.History.Features.Services;

public class HistoryService : IHistoryService
{
    private readonly IMongoBookDBContext _context;
    protected IMongoCollection<HistoryModel> _dbCollection;
    public HistoryService(IMongoBookDBContext context)
    {
        _context = context;
        _dbCollection = _context.GetCollection<HistoryModel>(typeof(HistoryModel).Name);
    }

    public async Task<bool> Add(HistoryModel historyModel)
    {
        await _dbCollection.InsertOneAsync(historyModel);
        return true;
    }

    public async Task<IEnumerable<HistoryResponse>> GetById(int accountId)
    {
        var result = await _dbCollection.Find(x=> x.AccountId == accountId).ToListAsync();
        var response = new List<HistoryResponse>();
        foreach (var item in result)
        {
            response.Add(new HistoryResponse()
            {
                AccountId = item.AccountId,
                Amount = item.Amount,
                CreationDate = item.CreationDate,
                IdTransaction = item.IdTransaction,
                Type = item.Type
            });
        }
        return response;
    }
}
